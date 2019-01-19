using UnityEngine;

namespace UnityAndroidSensors.Scripts.Core
{
    public enum Sensor
    {
        accelerometer,
        ambienttemperature,
        gamerotationvector,
        geomagneticrotationvector,
        gravity,
        gyroscope,
        gyroscopeuncalibrated,
        heartrate,
        light,
        linearacceleration,
        magneticfield,
        magneticfielduncalibrated,
        pressure,
        proximity,
        relativehumidity,
        rotationvector,
        significantmotion,
        stepcounter,
        stepdetector,
    }

    /**
     * Handles the connection between Unity and the android SensorManager
     */
    public class UnitySensorPlugin : MonoBehaviour
    {
        public static UnitySensorPlugin Instance { get; private set; }

        private const string SensorValues = "getSensorValues";
        private const string StartListening = "startSensorListening";
        private const string PathToJarClass = "de.marcusmeiburg.plugin.UnitySensorPlugin";
        private const string GetInstanceMethodName = "getInstance";
        private const string TerminateMethodName = "terminate";
        
        /* Reference to java instance*/
        private AndroidJavaObject plugin;

        private void Awake()
        {
            if (Instance == null) {
                Instance = this;
                
                #if UNITY_ANDROID
                    InitializePlugin();
                #endif
                
                DontDestroyOnLoad(this);
            } else if(Instance != this) {
                Destroy(this);
            }
        }

        public void StartListenting(Sensor sensor)
        {
            #if UNITY_ANDROID
                plugin?.Call(StartListening, sensor.ToString().ToLower());
            #endif
        }

        public float[] GetSensorValue(Sensor sensor)
        {
            if (plugin == null) {
                return new float[1];
            }
            
            #if UNITY_ANDROID
                return plugin.Call<float[]>(SensorValues, sensor.ToString().ToLower());
            #endif

            return null;
        }
        
        private void OnApplicationQuit ()
        {
            #if UNITY_ANDROID
                TerminatePlugin();
            #endif
        }
        
        private void InitializePlugin()
        {
            using (AndroidJavaClass pluginClass =
                new AndroidJavaClass(PathToJarClass)) {
                
                plugin = pluginClass
                    .CallStatic<AndroidJavaObject>(GetInstanceMethodName);
            }
        }

        private void TerminatePlugin()
        {
            if (plugin == null) {
                return;
            }

            plugin.Call(TerminateMethodName);
            plugin = null;
        }
    }
}