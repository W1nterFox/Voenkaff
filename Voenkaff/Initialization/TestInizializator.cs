﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using SerializablePicutre;
using Voenkaff.Properties;
using Voenkaff.Wrappers;
using Task = System.Threading.Tasks.Task;

namespace Voenkaff
{
    public class TestInizializator
    {
        public void Initialize(FormHello form)
        {
            try
            {
                var loader = new TestLoader();
                var tests = loader.LoadTestsFromFolder(new DynamicParams().Get().TestPath);
                VzvodAndLs.Set(tests.PlatoonList);
            }
            catch (Exception) { }
        }

        private void InitTest(Test objectsInCurrentTest)
        {

        }
    }
}