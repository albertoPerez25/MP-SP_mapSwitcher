using System;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using GTA.UI;
using iFruitAddon2;


namespace ScriptGTAV_1
{
    public class Main : Script
    {
        private ScriptSettings config;
        Boolean use_key;
        Keys my_key;
        Boolean loadedMP;
        Boolean use_phone;
        readonly CustomiFruit _iFruit;
        iFruitContact contactA;
        public Main()
        {
            Tick += OnTick;

            // Custom phone creation
            _iFruit = new CustomiFruit();

            KeyDown += onKeyDown;
            config = ScriptSettings.Load("scripts\\MP_MapSwitch.ini");
            loadedMP = config.GetValue<Boolean>("Bool", "MP_loaded", false);

            use_key = config.GetValue<Boolean>("Key", "use_key", false);
            if (use_key)
                my_key = config.GetValue<Keys>("Key", "my_key", Keys.K);

            use_phone = config.GetValue<Boolean>("Phone_contact", "use_phone", true);
            if (!use_key || use_phone) 
            {
                // New contact (no wait before picking up the phone)
                contactA = new iFruitContact("Switch MP map")
                {
                    DialTimeout = 1,            // Delay before answering
                    Active = true,              // true = the contact is available and will answer the phone
                    Icon = ContactIcon.Facebook // Contact's icon
                };
                contactA.Name = "Switch MP map";
                contactA.Answered += new ContactAnsweredEvent(switchMap);
                _iFruit.Contacts.Add(contactA); // Add the contact to the phone
            } 
        }

        void OnTick(object sender, EventArgs e)
        {
            if (use_phone)
                _iFruit.Update();
        }
        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (use_key && e.KeyCode == my_key)
            {
                switchMap(contactA);
            }
        }

        private void switchMap(iFruitContact contactA) 
        {
            _iFruit.Close();
            Function.Call((Hash)0x9BAE5AD2508DF078, true); // SET_INSTANCE_PRIORITY_MODE(true);
            Script.Wait(500);   // Crash fix
            Function.Call((Hash)0xE37B76C387BE28ED);       // REMOVE_IPL()

            if (!loadedMP)
            {
                //Load MP map:
                Notification.Show("Loading MP map...", true);
                Function.Call((Hash)0x0888C3502DBBEEF5);   // ON_ENTER_MP();
            }
            else
            {
                //Load SP map:
                Notification.Show("Loading SP map...", true);
                Function.Call((Hash)0xD7C10C4A637992C9);   // ON_ENTER_SP();
            }
            loadedMP = !loadedMP;
        }
    }
}
