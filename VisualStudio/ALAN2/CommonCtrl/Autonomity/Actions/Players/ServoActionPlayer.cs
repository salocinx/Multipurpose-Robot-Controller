
#region Usings
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    public class ServoActionPlayer {

        #region Fields
        private bool running;
        private bool playing;
        private int speed;
        private Arduino arduino;
        private ServoAction action;
        private Thread playbackThread;
        private Dictionary<int, Servo> motors = new Dictionary<int, Servo>();
        #endregion

        #region Lifecycle
        public ServoActionPlayer(Arduino arduino, ServoAction action, List<Servo> servos) {
            this.arduino = arduino;
            this.action = action;
            foreach(Servo servo in servos) {
                motors.Add(servo.Id, servo);
            }
        }
        #endregion

        #region Functions
        public void play(int speed) {
            if(playbackThread==null) {
                this.speed = speed;
                running = true;
                playing = true;
                playbackThread = new Thread(playback);
                playbackThread.Start();
            }
        }

        public void pause() {
            playing = false;
        }

        public void resume() {
            playing = true;
        }

        public void stop() {
            running = false;
        }
        #endregion

        #region Playback
        private void playback() {
            while(running) {
                // take one step for each individual sequence at a time (step must equal the SNAP size in the time control)
                for(int step=0; step<action.getMaxLength(); step+=Globals.DEFAULT_SERVO_RESOLUTION_X) {
                    if(playing) {
                        #region Logbook
                        Logger.Log(Level.FINE, "Check servo action at "+step+" [ms] for key points.", Debug.SERVOS);
                        #endregion
                        // check every sequence if there's a key point available at this step
                        foreach(ServoLayer layer in action.ServoLayers) {
                            if(layer.Visible) {
                                if(layer.isKeyPoint(step)) {
                                    Servo servo = motors[layer.ServoId];
                                    // get start and end keypoint for next sequence
                                    ServoKeyPoint point1 = layer.getKeyPointAt(step);
                                    ServoKeyPoint point2 = layer.getNextKeyPoint(step);
                                    // calculate the deltas over time to reach the next key point
                                    if(point1!=null && point2!=null) {
                                        uint time = (uint)((point2.X-point1.X)*(100.0*Math.Pow(speed, -1.0)));
                                        arduino.targetServoPosition(servo.Id, servo.Pin, servo.Address, point2.Y, time);
                                        #region Logbook
                                        Logger.Log(Level.INFO, "Set target on servo #D"+servo.Pin+" @ "+servo.Address+" from "+point1.Y+"% to "+point2.Y+"% with "+speed+"% speed within "+time+" [ms]", Debug.SERVOS);
                                        #endregion
                                    }
                                }
                            }
                        }
                        // wait to handle next step according to the speed: y = f(x) = a*x^b; where a=100%*min_resolution and b=-1 (power-function)
                        int wait = (int)(((double)(100*Globals.DEFAULT_SERVO_RESOLUTION_X))*Math.Pow(speed, -1.0));
                        // finally wait according to speed and resolution
                        Thread.Sleep(wait);
                    } else {
                        // wait until player is resumed or stopped
                        Thread.Sleep(32);
                    }
                }
                // stop playing after sequence is finished
                playing = false;
                running = false;
            }
            // reset playback thread
            playbackThread = null;
        }
        #endregion

    }

}