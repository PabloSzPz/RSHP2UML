using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cake.Engine;

namespace UML2RSHP
{
    public class Uml2RshpProcessor
    {
        //Hola chicoss sonrisa :(
        private static string ABC()
        {
            return "2942060414252746560D557D1153505B5D485103075D1A051452197E275A155C541E1F35582C3308367518011D71344A0C153E2D5B0F305E5407321D02303E2F037108356C140B220805307C5A5837293B24450635512E5D13421C02243C0B5314720963434062332C7D";
        } // ABC            

        public static CAKEEngine ConnectEngine(string databasePath)
        {
            CAKEEngine engine;
            string connectionString;
            connectionString = null;
            engine = new CAKEEngine(databasePath, string.Empty, string.Empty, Cake.ConnectionFactory.Enums.CAKEDBConnectionType.OleDBAccess, string.Empty, string.Empty, ref connectionString, false);
            CAKEEngine.set_OperationMode(false, ABC());
            engine.LoadGeneralElements();
            return engine;
        }

        public static bool TransformUml2Rshp(List<string> clases, List<Tuple<string, string>> relaciones, CAKEEngine engine)
        {
            bool success;
            success = engine != null;
            if (success)
            {
                ArtifactType artifactType;
                artifactType = engine.ClassArtifactType;
                Language language;
                language = engine.EnglishLanguage;
                Artifact myArtifact;
                myArtifact = new Artifact(engine, "Class diagram", artifactType, "physical name", "physical location", language);
                foreach (string clase in clases)
                {
                    Term luismaTerm;
                    luismaTerm = new Term(engine, clase, engine.NounType, language);
                    KE luismaKe;
                    luismaKe = new KE(myArtifact, luismaTerm, 0, 0);
                }
                RSHP newRelationship;

                Term term1, term2;
                foreach (Tuple<string, string> clasesRelacionadas in relaciones)
                {
                    newRelationship = new RSHP(myArtifact, engine.Semantics_AssociationType);
                    term1 = new Term(engine, clasesRelacionadas.Item1, engine.NounType, language);
                    term2 = new Term(engine, clasesRelacionadas.Item2, engine.NounType, language);
                    KE ke1, ke2;

                    ke1 = new KE(newRelationship, term1, 1, 0);
                    if (engine.Semantics_AssociationType.IsSymmetrical)
                    {
                        ke2 = new KE(newRelationship, term2, 1, 0);
                    }
                    else
                    {
                        ke2 = new KE(newRelationship, term2, 2, 0);
                    }

                }
            }
            return success;
        }

    }
}
