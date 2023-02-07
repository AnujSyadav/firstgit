using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamProjectPro.DB;
using TeamProjectPro.Models;

namespace TeamProjectPro.Controllers
{
    public class EmpController : Controller
    {
        ProjectEntities1 dbconn = new ProjectEntities1();
        public ActionResult Read()
        {
            var data = dbconn.GetAllDataNEw().ToList();

            List<EmpModel> obj = new List<EmpModel>();

            for (int i = 0; i < data.Count; i++)
            {
                obj.Add(new EmpModel()
                {
                    eid = data[i].eid,
                    ename = data[i].ename,
                    edesig = data[i].edesig,
                    Dob = data[i].dob,
                    Hno = data[i].hno,
                    Build = data[i].build,
                    Zipcode = data[i].zipcode,
                    tname = data[i].tname,
                    email = data[i].email,
                    pass = data[i].pass,
                    langname = data[i].langname
                });
            }
            return View(obj);
        }

        [HttpGet]
        public ActionResult Delete(int eid)
        {
            dbconn.DeleteData(eid);
            dbconn.SaveChanges();
            return RedirectToAction("Read");
        }

        [HttpGet]
        public ActionResult AddEmp()
        {


            Session["Check"] = "Add";
            var list = dbconn.technologies.ToList();
             ViewBag.List = new SelectList(list, "tid", "tname");
        
            return View(); 
        }
        [HttpPost]
        public ActionResult AddEmp(EmpModel obj,bool h,bool e, bool f , bool g)
        {
            string l1, l2, l3, l4;
            if (obj.eid == 0)
            {
                if (h == true)
                {
                    l1 = "L001";
                }
                else
                {
                    l1 = "0000";
                }

                if (e == true)
                {
                    l2 = "L002";
                }
                else
                {
                    l2 = "0000";
                }

                if (f == true)
                {
                    l3 = "L003";
                }
                else
                {
                    l3 = "0000";
                }

                if (g == true)
                {
                    l4 = "L004";
                }
                else
                {
                    l4 = "0000";
                }
                dbconn.AddData(obj.ename, obj.edesig, obj.Dob, obj.Adid, obj.Hno, obj.Build, obj.Zipcode, obj.tid, obj.email, obj.pass, l1, l2, l3, l4);
                dbconn.SaveChanges();
            }
            else
            {
                if (h == true)
                {
                    l1 = "L001";
                }
                else
                {
                    l1 = "0000";
                }

                if (e == true)
                {
                    l2 = "L002";
                }
                else
                {
                    l2 = "0000";
                }

                if (f == true)
                {
                    l3 = "L003";
                }
                else
                {
                    l3 = "0000";
                }

                if (g == true)
                {
                    l4 = "L004";
                }
                else
                {
                    l4 = "0000";
                }
                dbconn.EditDatanew(obj.eid, obj.ename, obj.edesig, obj.Dob, obj.Adid, obj.Hno, obj.Build, obj.Zipcode, obj.tid, obj.email, obj.pass, l1, l2, l3, l4);
                dbconn.SaveChanges();
            }
            return RedirectToAction("Read");
        }

        
        public ActionResult Edit(int eid)
        {
            
            Session["Check"] = "Edit";
            var data = dbconn.showdatanew(eid).ToList();
            var data1 = dbconn.showlang(eid).ToList();
            EmpModel obj = new EmpModel();

            obj.ename = data[0].ename;
            obj.edesig = data[0].edesig;
            obj.Dob = data[0].dob;
            obj.Adid = data[0].adid;
            obj.Hno = data[0].hno;
            obj.Build = data[0].build;
            obj.Zipcode = data[0].zipcode;
            obj.tid = data[0].tid;
            obj.email = data[0].email;
            obj.pass = data[0].pass;
            for (int i = 0; i < data1.Count; i++)
            {
                if (data1[i] == "L001")
                {
                    obj.l1 = data1[i];
                }
                else if (data1[i] == "L002")
                {
                    obj.l2 = data1[i];
                }
                else if (data1[i] == "L003")
                {
                    obj.l3 = data1[i];
                }
                else
                {
                    obj.l4 = data1[i];
                }
            }

            var list = dbconn.technologies.ToList();
            ViewBag.List = new SelectList(list, "tid", "tname");
            return View("AddEmp",obj);
        }

    }
}