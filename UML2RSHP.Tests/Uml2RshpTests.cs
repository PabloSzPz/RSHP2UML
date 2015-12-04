using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace UML2RSHP.Tests
{
    public class Uml2RshpTests
    {  
        [Test]
        public void ConnectionEngine() { 
            Cake.Engine.CAKEEngine engine;
            engine = UML2RSHP.Uml2RshpProcessor.ConnectEngine("CAKE v15.1.mdb");
            Assert.IsNotNull(engine);
        }

        [Test]
        public void Test() {
            Cake.Engine.CAKEEngine engine;
            engine = UML2RSHP.Uml2RshpProcessor.ConnectEngine("CAKE v15.1.mdb");
            Assert.IsNotNull(engine);
            List<string> clases;
            clases = new List<string>();
            clases.Add("Usuario");
            clases.Add("Administrador");
            clases.Add("Contable");
            List<Tuple<string, string>> relaciones;
            relaciones = new List<Tuple<string, string>>();
            relaciones.Add(new Tuple<string, string>("Miguel", "Pablo"));
            relaciones.Add(new Tuple<string, string>("Teresa", "Maribel"));
            relaciones.Add(new Tuple<string, string>("Teresa", "Esther"));
            UML2RSHP.Uml2RshpProcessor.TransformUml2Rshp(clases, relaciones, engine);
        }
    }
}
