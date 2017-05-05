using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final.Models.DB;
using Final.Models.ViewModel;

namespace Final.Models.EntityManager
{
    public class ClassManager
    {
        public void AddClass(classMaster newClass) {
            using (CE_WebEntities db = new CE_WebEntities()) {
                classMaster CM = new classMaster();
                CM.className = newClass.className;
                CM.classDescription = newClass.classDescription;
                CM.classPrice = newClass.classPrice;
                CM.classSessions = newClass.classSessions;

                db.classMasters.Add(CM);
                db.SaveChanges();
            }

        }


        

    }
 
}