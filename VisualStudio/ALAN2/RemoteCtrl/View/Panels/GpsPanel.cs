
#region Usings
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class GpsPanel : UserControl, iLocalUpdate {

        #region Links
        // GMap Download
        // http://greatmaps.codeplex.com/
        // GMap Tutorial
        // http://www.independent-software.com/gmap-net-beginners-tutorial-maps-markers-polygons-routes-updated-for-visual-studio-2015-and-gmap-net-1-7/
        #endregion

        #region Fields
        private Agent agent;
        private GPS gps;
        private GMapMarker marker;
        #endregion

        #region Lifecycle
        public GpsPanel(Agent agent, GPS gps) {
            this.agent = agent;
            this.gps = gps;
            InitializeComponent();
            initializeGui();
            agent.subscribeLocalUpdate(this);
        }

        private void initializeGui() {
            this.UIThreadInvoke(delegate {
                // initialize map controls
                mapGps.ShowCenter = false;
                mapGps.MapProvider = BingSatelliteMapProvider.Instance;
                GMaps.Instance.Mode = AccessMode.ServerOnly;
                mapGps.SetPositionByKeywords("Sankt Gallen, Switzerland");
                // initialize map marker
                GMapOverlay markers = new GMapOverlay("markers");
                marker = new GMarkerGoogle(new PointLatLng(gps.Latitude, gps.Longitude), GMarkerGoogleType.blue_dot);
                marker.IsVisible = false;
                markers.Markers.Add(marker);
                mapGps.Overlays.Add(markers);
                // initialize other controls
                txtSatellites.Text = gps.Satellites.ToString();
                txtLatitude.Text = gps.Latitude.ToString("0.00000");
                txtLongitude.Text = gps.Longitude.ToString("0.00000");
                txtAltitude.Text = gps.Altitude.ToString("0.00");
                txtSpeed.Text = gps.Speed.ToString("0.00");
            });
        }
        #endregion

        #region Local Update
        public void initializeLocalUpdate() {
            onLocalUpdate();
        }

        public iComponent getInterest() {
            return gps;
        }

        public List<iComponent> getInterests() {
            return null;
        }

        public void onLocalUpdate() {
            this.UIThreadInvoke(delegate {
                // update map position
                if(gps.Latitude!=0 && gps.Longitude!=0) {
                    marker.Position = new PointLatLng(gps.Latitude, gps.Longitude);
                    marker.IsVisible = true;
                    if(boxAutoZoom.Checked) mapGps.Zoom = 18;
                    if(boxAutoPosition.Checked) mapGps.Position = new PointLatLng(gps.Latitude, gps.Longitude);
                }
                // update other controls
                txtSatellites.Text = gps.Satellites.ToString();
                txtLatitude.Text = gps.Latitude.ToString("0.00000");
                txtLongitude.Text = gps.Longitude.ToString("0.00000");
                txtAltitude.Text = gps.Altitude.ToString("0.00");
                txtSpeed.Text = gps.Speed.ToString("0.00");
            });
        }
        #endregion

        #region Event-Handling (Gui)
        /* This is an overload instead of attaching the Load(*) event manually.
         * Just copy and paste this code to other user-control classes. */
        protected override void OnLoad(EventArgs evt) {
            this.AutoSize = false;
            this.Dock = DockStyle.Fill;
            base.OnLoad(evt);
        }

        private void boxSatelliteView_CheckedChanged(object sender, EventArgs evt) {
            if(boxSatelliteView.Checked) {
                mapGps.MapProvider = BingSatelliteMapProvider.Instance;
            } else {
                mapGps.MapProvider = BingMapProvider.Instance;
            }
        }
        #endregion

    }

}
