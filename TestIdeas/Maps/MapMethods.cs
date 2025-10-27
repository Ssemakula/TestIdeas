using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestIdeas.Strings;

namespace TestIdeas.Maps
{
    public enum MapProvider
    {
        OpenStreetMap,
        GoogleMaps,
        BingMaps,
    }

    public static class MapMethods
    {
        public static void ShowMap(string location)
        {
            double? latitude;
            double? longitude;
            // Try to parse coordinates from the location string
            (latitude, longitude) = location.TryParseCoordinates();

            if (latitude == null || longitude == null)
            {
                throw new ArgumentException("Invalid latitude and longitude coordinates.");
            }

            // Validate coordinate ranges
            if (latitude < -90 || latitude > 90 || longitude < -180 || longitude > 180)
            {
                throw new ArgumentException("Latitude must be between -90 and 90.\nLongitude must be between -180 and 180.");
            }

            OpenMapInBrowser(latitude, longitude);
        }

        public static void OpenMapInBrowser(double? latitude, double? longitude, MapProvider provider = MapProvider.GoogleMaps)
        {
            if (latitude == null || longitude == null)
                throw new ArgumentException("Invalid latitude and longitude coordinates.");

            if (latitude < -90 || latitude > 90 || longitude < -180 || longitude > 180)
                throw new ArgumentException("Latitude must be between -90 and 90.\nLongitude must be between -180 and 180.");

            string url;
            switch (provider)
            {
                case MapProvider.GoogleMaps:
                    url = $"https://www.google.com/maps?q={latitude},{longitude}";
                    break;

                case MapProvider.OpenStreetMap:
                    url = $"https://www.openstreetmap.org/?mlat={latitude}&mlon={longitude}#map=15/{latitude}/{longitude}";
                    break;

                case MapProvider.BingMaps:
                    url = $"https://www.bing.com/maps?q={latitude},{longitude}";
                    break;

                default:
                    url = $"https://www.google.com/maps?q={latitude},{longitude}";
                    break;
            }

            System.Diagnostics.Process.Start(url);
        }

        public static void OpenMapInBrowser(string locationName, MapProvider provider = MapProvider.GoogleMaps)
        {
            if (string.IsNullOrWhiteSpace(locationName))
                throw new ArgumentException("Location name cannot be empty.");

            string url;
            string encodedName = Uri.EscapeDataString(locationName);

            switch (provider)
            {
                case MapProvider.GoogleMaps:
                    // Google Maps search
                    url = $"https://www.google.com/maps/search/?api=1&query={encodedName}";
                    break;

                case MapProvider.BingMaps:
                    // Bing Maps search
                    url = $"https://www.bing.com/maps?q={encodedName}";
                    break;

                case MapProvider.OpenStreetMap:
                    // OpenStreetMap search
                    url = $"https://www.openstreetmap.org/search?query={encodedName}";
                    break;

                default:
                    url = $"https://www.google.com/maps/search/?api=1&query={encodedName}";
                    break;
            }

            System.Diagnostics.Process.Start(url);
        }

        private static string GenerateSimpleMapHtml(double latitude, double longitude, string locationName)
        {
            // Simple OpenStreetMap embed without JavaScript
            string openStreetMapUrl = $"https://www.openstreetmap.org/export/embed.html?" +
                                     $"bbox={longitude - 0.01}%2C{latitude - 0.01}%2C{longitude + 0.01}%2C{latitude + 0.01}&" +
                                     $"layer=mapnik&" +
                                     $"marker={latitude}%2C{longitude}";

            string html = $@"
            <!DOCTYPE html>
            <html>
            <head>
                <title>{locationName}</title>
                <style>
                    body {{ margin: 0; padding: 0; }}
                    iframe {{ width: 100%; height: 100vh; border: none; }}
                </style>
            </head>
            <body>
                <iframe src='{openStreetMapUrl}'></iframe>
                <br/>
                <small>
                    <a href='https://www.openstreetmap.org/?mlat={latitude}&mlon={longitude}#map=15/{latitude}/{longitude}'>
                        View Larger Map
                    </a>
                </small>
            </body>
            </html>";

            return html;
        }

        private static string GenerateMapHtml(double latitude, double longitude, string locationName)
        {
            // Calculate bounding box for the map view
            double margin = 0.01; // ~1km margin
            double minLon = longitude - margin;
            double maxLon = longitude + margin;
            double minLat = latitude - margin;
            double maxLat = latitude + margin;

            // Using OpenStreetMap with Leaflet.js for better interactivity
            string html = $@"
            <!DOCTYPE html>
            <html>
            <head>
                <title>OpenStreetMap</title>
                <meta charset='utf-8' />
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <link rel='stylesheet' href='https://unpkg.com/leaflet@1.7.1/dist/leaflet.css' />
                <script src='https://unpkg.com/leaflet@1.7.1/dist/leaflet.js'></script>
                <style>
                    body {{ margin: 0; padding: 0; }}
                    #map {{ height: 100vh; width: 100%; }}
                    .custom-popup {{ font-family: Arial, sans-serif; }}
                    .coordinates {{ font-size: 12px; color: #666; }}
                </style>
            </head>
            <body>
                <div id='map'></div>

                <script>
                    // Initialize the map
                    var map = L.map('map').setView([{latitude}, {longitude}], 15);

                    // Add OpenStreetMap tiles
                    L.tileLayer('https://{{s}}.tile.openstreetmap.org/{{z}}/{{x}}/{{y}}.png', {{
                        attribution: '&copy; <a href=""https://www.openstreetmap.org/copyright"">OpenStreetMap</a> contributors',
                        maxZoom: 19
                    }}).addTo(map);

                    // Add marker with popup
                    var marker = L.marker([{latitude}, {longitude}]).addTo(map);
                    marker.bindPopup(`
                        <div class='custom-popup'>
                            <strong>{locationName}</strong><br>
                            <span class='coordinates'>
                                Lat: {latitude:F6}<br>
                                Lon: {longitude:F6}
                            </span>
                        </div>
                    `).openPopup();

                    // Optional: Add a circle to show accuracy/area of interest
                    L.circle([{latitude}, {longitude}], {{
                        color: 'red',
                        fillColor: '#f03',
                        fillOpacity: 0.1,
                        radius: 500
                    }}).addTo(map);

                    // Optional: Fit map to show marker with some padding
                    map.fitBounds([
                        [{minLat}, {minLon}],
                        [{maxLat}, {maxLon}]
                    ]);
                </script>
            </body>
            </html>";

            return html;
        }
    }
}