using System;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using GTA.Math;


namespace ScriptGTAV_1
{
    public class Main : Script
    {
        Vehicle car;
        private ScriptSettings config; 
        Keys my_key;
        Boolean loadedMP;
        public Main()
        {
            Tick += onTick;
            KeyDown += onKeyDown;
            config = ScriptSettings.Load("scripts\\MP_MapSwitch.ini"); 
            my_key = config.GetValue<Keys>("Key", "my_key", Keys.K);
            loadedMP = config.GetValue<Boolean>("Bool", "MP_loaded", false);
        }
        private void onTick(object sender, EventArgs e)
        {

        }
        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == my_key)
            {
                Function.Call(Hash._0x9BAE5AD2508DF078, true); // SET_INSTANCE_PRIORITY_MODE(true);
                Script.Wait(500);   // Crash fix
                Function.Call(Hash._0xE37B76C387BE28ED);       // REMOVE_IPL()

                if (!loadedMP)
                {
                    //Load MP map:
                    UI.Notify("Loading MP map...");
                    Function.Call(Hash._0x0888C3502DBBEEF5);   // ON_ENTER_MP();
                    loadedMP = !loadedMP;
                }
                else 
                {
                    //Load SP map:
                    UI.Notify("Loading SP map...");
                    Function.Call(Hash._0xD7C10C4A637992C9);   // ON_ENTER_SP();
                    loadedMP = !loadedMP;
                }
            }
        }
    }
}
