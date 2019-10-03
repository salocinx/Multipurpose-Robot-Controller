
#region Usings
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DirectShowLib;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class HwCamera {

        #region Fields
        private int id;
        private string guid;
        private string name;
        private string devicePath;
        private List<Resolution> resolutions;
        #endregion

        #region Lifecycle
        public HwCamera(int id, DsDevice camera) {
            this.id = id;
            this.guid = camera.ClassID.ToString();
            this.name = camera.Name;
            this.devicePath = camera.DevicePath;
            this.resolutions = getAvailableResolutions(camera);
        }
        #endregion

        #region Functions
        private List<Resolution> getAvailableResolutions(DsDevice camera) {
            try {

                List<Resolution> result = new List<Resolution>();

                int hr, max = 0, bitCount = 0;
                IBaseFilter sourceFilter = null;
                var m_FilterGraph2 = new FilterGraph() as IFilterGraph2;
                hr = m_FilterGraph2.AddSourceFilterForMoniker(camera.Mon, null, camera.Name, out sourceFilter);
                var pRaw2 = DsFindPin.ByCategory(sourceFilter, PinCategory.Capture, 0);

                VideoInfoHeader v = new VideoInfoHeader();
                IEnumMediaTypes mediaTypeEnum;
                hr = pRaw2.EnumMediaTypes(out mediaTypeEnum);

                AMMediaType[] mediaTypes = new AMMediaType[1];
                IntPtr fetched = IntPtr.Zero;
                hr = mediaTypeEnum.Next(1, mediaTypes, fetched);

                while(fetched != null && mediaTypes[0] != null) {
                    Marshal.PtrToStructure(mediaTypes[0].formatPtr, v);
                    if(v.BmiHeader.Size != 0 && v.BmiHeader.BitCount != 0) {
                        if(v.BmiHeader.BitCount > bitCount) {
                            result.Clear();
                            max = 0;
                            bitCount = v.BmiHeader.BitCount;
                        }
                        if(!isEnlistedResolution(result, v.BmiHeader.Width, v.BmiHeader.Height)) {
                            result.Add(new Resolution(v.BmiHeader.Width, v.BmiHeader.Height));
                        }
                        if(v.BmiHeader.Width > max || v.BmiHeader.Height > max) {
                            max = (Math.Max(v.BmiHeader.Width, v.BmiHeader.Height));
                        }
                    }
                    hr = mediaTypeEnum.Next(1, mediaTypes, fetched);
                }

                return result;

            } catch(Exception ex) {
                #region Logbook
                Logger.Log(Level.WARNING, "Could not determine available camera resolutions.", ex);
                #endregion
                return new List<Resolution>();
            }
        }

        private bool isEnlistedResolution(List<Resolution> result, int width, int height) {
            foreach(Resolution resolution in result) {
                if(resolution.Width==width && resolution.Height==height) {
                    return true;
                }
            }
            return false;
        }

        public string getDescription() {
            string result = "";
            result += "Camera #"+id+" ["+name+"]:"+Environment.NewLine;
            result += " - GUID = "+guid.ToString()+Environment.NewLine;
            result += " - Path = "+devicePath+Environment.NewLine;
            result += " - Resolutions: "+Environment.NewLine;
            foreach(Resolution resolution in resolutions) {
                result += "   - "+resolution.ToString()+Environment.NewLine;
            }
            return result;
        }

        public override string ToString() {
            return "USB#"+id;
        }
        #endregion

        #region Properties
        public int Id {
            get { return id; }
        }

        public string Guid {
            get { return guid; }
        }

        public string Name {
            get { return name; }
        }

        public string DevicePath {
            get { return devicePath; }
        }

        public List<Resolution> Resolutions {
            get { return resolutions; }
        }
        #endregion

    }

}