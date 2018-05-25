using System;
using System.Collections.Generic;

namespace xBountyHunter.Extras
{
    public class listaFugitivos
    {
        public List<Models.mFugitivos> ocFugitivos;
        private databaseManager DB = new databaseManager();

        public listaFugitivos()
        {
            /*ocFugitivos = new List<Models.mFugitivos>();

            ocFugitivos.Add(new Models.mFugitivos
            {
                Name = "Armando Olmos",
            });
            ocFugitivos.Add(new Models.mFugitivos
            {
                Name = "Edgar Guevara",
            });
            ocFugitivos.Add(new Models.mFugitivos
            {
                Name = "Guillermo Torres",
            });
            ocFugitivos.Add(new Models.mFugitivos
            {
                Name = "Daniel Flores",
            });
            ocFugitivos.Add(new Models.mFugitivos
            {
                Name = "Emilio Vazquez",
            });*/
        }

        public List<Models.mFugitivos> selectNoCaptured()
        {
            ocFugitivos = DB.selectNoCaptured();
            return ocFugitivos;
        }

        public List<Models.mFugitivos> selectCaptured()
        {
            ocFugitivos = DB.selectCaptured();
            return ocFugitivos;
        }
    }
}
