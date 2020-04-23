using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;




namespace DAL
{
    public class Dal_XML_imp : Idal
    {
        XElement ChilRoot;
        string childPath = @"Childxml.xml";
        XElement NannyRoot;
        string nannyPath = @"Nannyxml.xml";
        XElement MotherRoot;
        string motherPath = @"Motherxml.xml";
        XElement ContractRoot;
        string contractPath = @"Contractxml.xml";
        XElement contractCodeRoot;
        string contractCodePath = @"Config.xml";
        //public static int contractCode = 0;
        public Dal_XML_imp()
        {
            try
            {

                if (!File.Exists(nannyPath))
                {
                    NannyRoot = new XElement("nannies");
                    NannyRoot.Save(nannyPath);
                }
                else
                    NannyRoot = XElement.Load(nannyPath);
                if (!File.Exists(motherPath))
                {
                    MotherRoot = new XElement("mothers");
                    MotherRoot.Save(motherPath);
                }
                else
                    MotherRoot = XElement.Load(motherPath);

                if (!File.Exists(childPath))
                {
                    ChilRoot = new XElement("childs");
                    ChilRoot.Save(childPath);
                }
                else
                    ChilRoot = XElement.Load(childPath);
                if (!File.Exists(contractPath))
                {
                    ContractRoot = new XElement("contracts");
                    ContractRoot.Save(contractPath);

                }
                else
                    ContractRoot = XElement.Load(contractPath);
                if (!File.Exists(contractCodePath))
                {
                    contractCodeRoot = new XElement("ContractCode");
                    contractCodeRoot.Save(contractCodePath);
                    XElement code = new XElement("code", 0);
                    XElement codecode = new XElement("codecode", 1234);
                    contractCodeRoot.Add(new XElement("contractCode", codecode, code));
                    contractCodeRoot.Save(contractCodePath);
                }
                else
                    contractCodeRoot = XElement.Load(contractCodePath);
            }
          
            catch { throw new Exception("File upload problem"); }
        }

        private void CreateFiles()
        {
            ChilRoot = new XElement("childs");
            ChilRoot.Save(childPath);
            MotherRoot = new XElement("mothers");
            MotherRoot.Save(motherPath);
            NannyRoot = new XElement("nannies");
            NannyRoot.Save(nannyPath);
            ContractRoot = new XElement("contracts");
            ContractRoot.Save(contractPath);


            contractCodeRoot = new XElement("ContractCode");
            contractCodeRoot.Save(contractCodePath);
            XElement code = new XElement("code", 0);
            XElement codecode = new XElement("codecode", 1234);
            contractCodeRoot.Add(new XElement("contractCode", codecode, code));
            contractCodeRoot.Save(contractCodePath);
        }
        private void LoadData()
        {
            try
            {
                ChilRoot = XElement.Load(childPath);
                ContractRoot = XElement.Load(contractPath);
                NannyRoot = XElement.Load(nannyPath);
                MotherRoot = XElement.Load(motherPath);

            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        public void AddChild(BE.Child child)
        {
            XElement xElement = (from item in ChilRoot.Elements()
                                 where item.Element("ChildId").Value == child.ChildId
                                 select item).FirstOrDefault();
            if (xElement != null)
                ApdateChild(child);
            else
            {
                XElement id = new XElement("ChildId", child.ChildId);
                XElement firstName = new XElement("ChildFistName", child.ChildFistName);
                XElement momId = new XElement("MomId", child.MomId);
                XElement birth = new XElement("ChildBirth", child.ChildBirth);
                XElement spacial = new XElement("SpecialBoy", child.SpecialBoy);
                XElement details = new XElement("SpecialBoyDetails", child.SpecialBoyDetails);

                ChilRoot.Add(new XElement("child", id, firstName, momId, birth, spacial, details));
                ChilRoot.Save(childPath);
            }
        }
        public BE.Child ChildFromElement(XElement xElement)
        {
            BE.Child temp = new BE.Child();
            temp.ChildId = xElement.Element("ChildId").Value;
            temp.ChildBirth =Convert.ToDateTime(xElement.Element("ChildBirth").Value);
            temp.ChildFistName = xElement.Element("ChildFistName").Value;
            temp.MomId = xElement.Element("MomId").Value;
            temp.SpecialBoy =Convert.ToBoolean( xElement.Element("SpecialBoy").Value);
            temp.SpecialBoyDetails = xElement.Element("SpecialBoyDetails").Value;
           
            //foreach (PropertyInfo item in typeof(BE.Child).GetProperties())
            //{
            //    TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
            //    object convertValue = typeConverter.ConvertFromString(xElement.Element(item.Name).Value);

            //    if (item.CanWrite)
            //        item.SetValue(temp, convertValue);
            //}
            return temp;

        }
        public void ApdateChild(BE.Child child)
        {
            XElement xElement =
                (from item in ChilRoot.Elements()
                 where (Convert.ToString(item.Element("ChildId").Value)) == child.ChildId
                 select item).FirstOrDefault();
            if (xElement == null)
                throw new Exception("we didnt find this child");
            xElement.Element("ChildId").Value = child.ChildId;
            xElement.Element("ChildFistName").Value = child.ChildFistName;
            xElement.Element("MomId").Value = child.MomId;
            xElement.Element("ChildBirth").Value = child.ChildBirth.ToString();
            xElement.Element("SpecialBoy").Value = child.SpecialBoy.ToString();
            xElement.Element("SpecialBoyDetails").Value = child.SpecialBoyDetails;
            ChilRoot.Save(childPath);

        }
        public void DelChild(BE.Child temp)
        {
            try
            {
                XElement xElement =
                   (from item in ChilRoot.Elements()
                    where (Convert.ToString(item.Element("id").Value)) == temp.ChildId
                    select item).FirstOrDefault();
                xElement.Remove();
                ChilRoot.Save(childPath);
            }
            catch
            { throw new Exception("canot delete this child"); }
        }
       


        public void DelNanny(BE.Nanny temp)
        {
            try
            {
                XElement xElement =
                   (from item in NannyRoot.Elements()
                    where (Convert.ToString(item.Element("NannyId").Value)) == temp.NannyId
                    select item).FirstOrDefault();
                xElement.Remove();
                NannyRoot.Save(nannyPath);
            }
            catch
            { throw new Exception("canot delete this nanny"); }
        }
        public void AddNanny(BE.Nanny nanny)
        {
            XElement xElement =
                   (from item in NannyRoot.Elements()
                    where (Convert.ToString(item.Element("NannyId").Value)) == nanny.NannyId
                    select item).FirstOrDefault();
            if (xElement != null)
                ApdateNanny(nanny);
            else
            {
                XElement id = new XElement("NannyId", nanny.NannyId);
                XElement firstName = new XElement("NannyFirstName", nanny.NannyFirstName);
                XElement lastName = new XElement("NannyLastName", nanny.NannyLastName);
                XElement phone = new XElement("NannyPhone", nanny.NannyPhone);
                XElement adrress = new XElement("NannyAddress", nanny.NannyAddress);
                XElement elevators = new XElement("IsElevators", nanny.IsElevators);
                XElement birth = new XElement("NannyBirth", nanny.NannyBirth);
                XElement flat = new XElement("Nannyflat", nanny.Nannyflat);
                XElement experience = new XElement("NannyExperience", nanny.NannyExperience);
                XElement maxChild = new XElement("MaxChild", nanny.MaxChild);
                XElement minAge = new XElement("MinAge", nanny.MinAge);
                XElement maxAge = new XElement("MaxAge", nanny.MaxAge);
                XElement isHours = new XElement("IsHours", nanny.IsHours);
                XElement moneyForHour = new XElement("MoneyForHour", nanny.MoneyForHour);
                XElement moneyForMonth = new XElement("MoneyForMonth", nanny.MoneyForMonth);

                XElement sun = new XElement("sun", nanny.Days[0]);
                XElement mon = new XElement("mon", nanny.Days[1]);
                XElement tue = new XElement("tue", nanny.Days[2]);
                XElement wed = new XElement("wed", nanny.Days[3]);
                XElement thu = new XElement("thu", nanny.Days[4]);
                XElement fri = new XElement("fri", nanny.Days[5]);

                XElement aa = new XElement("t00", nanny.Times[0][0]);
                XElement ab = new XElement("t01", nanny.Times[1][0]);
                XElement ac = new XElement("t02", nanny.Times[2][0]);
                XElement ad = new XElement("t03", nanny.Times[3][0]);
                XElement ae = new XElement("t04", nanny.Times[4][0]);
                XElement af = new XElement("t05", nanny.Times[5][0]);
                XElement ba = new XElement("t10", nanny.Times[0][1]);
                XElement bb = new XElement("t11", nanny.Times[1][1]);
                XElement bc = new XElement("t12", nanny.Times[2][1]);
                XElement bd = new XElement("t13", nanny.Times[3][1]);
                XElement be = new XElement("t14", nanny.Times[4][1]);
                XElement bf = new XElement("t15", nanny.Times[5][1]);

                XElement tttt = new XElement("Times", aa, ab, ac, ad, ae, af, ba, bb, bc, bd, be, bf);
                XElement isTMTVocation = new XElement("IsTMTVocation", nanny.IsTMTVocation);

                XElement days = new XElement("Days", sun, mon, tue, wed, thu, fri);
                XElement recommendation = new XElement("Recommendation", nanny.Recommendation);
                XElement isspecial = new XElement("Isspecial", nanny.Isspecial);

                NannyRoot.Add(new XElement("nanny", days, tttt, firstName, lastName, phone, adrress, elevators, birth, flat, experience, maxAge, maxChild, minAge, isHours, moneyForHour, moneyForMonth, id, isTMTVocation, isspecial, recommendation));
                NannyRoot.Save(nannyPath);
            }
        }
        public void ApdateNanny(BE.Nanny nanny)
        {
            XElement xElement =
                   (from item in NannyRoot.Elements()
                    where (Convert.ToString(item.Element("NannyId").Value)) == nanny.NannyId
                    select item).FirstOrDefault();
            if (xElement == null)
                throw new Exception("canot update this nanny");
            xElement.Element("NannyFirstName").Value = nanny.NannyFirstName;
            xElement.Element("NannyLastName").Value = nanny.NannyLastName;
            xElement.Element("NannyPhone").Value = nanny.NannyPhone;
            xElement.Element("NannyAddress").Value = nanny.NannyAddress;
            xElement.Element("IsElevators").Value = nanny.IsElevators.ToString();
            xElement.Element("NannyBirth").Value = nanny.NannyBirth.ToString();
            xElement.Element("Nannyflat").Value = nanny.Nannyflat.ToString();
            xElement.Element("NannyExperience").Value = nanny.NannyExperience.ToString();
            xElement.Element("MaxChild").Value = nanny.MaxChild.ToString();
            xElement.Element("MinAge").Value = nanny.MinAge.ToString();
            xElement.Element("MaxAge").Value = nanny.MaxAge.ToString();
            xElement.Element("IsHours").Value = nanny.IsHours.ToString();
            xElement.Element("MoneyForHour").Value = nanny.MoneyForHour.ToString();
            xElement.Element("MoneyForMonth").Value = nanny.MoneyForMonth.ToString();
            xElement.Element("Days").Element("sun").Value = nanny.Days[0].ToString();
            xElement.Element("Days").Element("mon").Value = nanny.Days[1].ToString();
            xElement.Element("Days").Element("tue").Value = nanny.Days[2].ToString();
            xElement.Element("Days").Element("wed").Value = nanny.Days[3].ToString();
            xElement.Element("Days").Element("thu").Value = nanny.Days[4].ToString();
            xElement.Element("Days").Element("fri").Value = nanny.Days[5].ToString();

            xElement.Element("Times").Element("t00").Value = nanny.Times[0][0];
            xElement.Element("Times").Element("t01").Value = nanny.Times[1][0];
            xElement.Element("Times").Element("t02").Value = nanny.Times[2][0];
            xElement.Element("Times").Element("t03").Value = nanny.Times[3][0];
            xElement.Element("Times").Element("t04").Value = nanny.Times[4][0];
            xElement.Element("Times").Element("t05").Value = nanny.Times[5][0];
            xElement.Element("Times").Element("t10").Value = nanny.Times[0][1];
            xElement.Element("Times").Element("t11").Value = nanny.Times[1][1];
            xElement.Element("Times").Element("t12").Value = nanny.Times[2][1];
            xElement.Element("Times").Element("t13").Value = nanny.Times[3][1];
            xElement.Element("Times").Element("t14").Value = nanny.Times[4][1];
            xElement.Element("Times").Element("t15").Value = nanny.Times[5][1];


            xElement.Element("IsTMTVocation").Value = nanny.IsTMTVocation.ToString();
            xElement.Element("Recommendation").Value = nanny.Recommendation;
            xElement.Element("Isspecial").Value = nanny.Isspecial.ToString();

            NannyRoot.Save(nannyPath);



        }

        public void AddMother(BE.Mother mother)
        {
            XElement xElement =
                 (from item in MotherRoot.Elements()
                  where (Convert.ToString(item.Element("MomId").Value)) == mother.MomId
                  select item).FirstOrDefault();
            if (xElement != null)
                ApdateMother(mother);
            else
            {
                XElement id = new XElement("MomId", mother.MomId);
                XElement firstName = new XElement("MomFirstName", mother.MomFirstName);
                XElement lastName = new XElement("MomLastName", mother.MomLastName);
                XElement phone = new XElement("MomPhone", mother.MomPhone);
                XElement adrress = new XElement("MomAddress", mother.MomAddress);
                XElement babyAdrress = new XElement("BabyAddress", mother.BabyAddress);

                XElement sun = new XElement("sun", mother.Days[0]);
                XElement mon = new XElement("mon", mother.Days[0]);
                XElement tue = new XElement("tue", mother.Days[0]);
                XElement wed = new XElement("wed", mother.Days[0]);
                XElement thu = new XElement("thu", mother.Days[0]);
                XElement fri = new XElement("fri", mother.Days[0]);
                XElement sat = new XElement("sat", mother.Days[0]);

                XElement aa = new XElement("t00", mother.Times[0][0]);
                XElement ab = new XElement("t01", mother.Times[1][0]);
                XElement ac = new XElement("t02", mother.Times[2][0]);
                XElement ad = new XElement("t03", mother.Times[3][0]);
                XElement ae = new XElement("t04", mother.Times[4][0]);
                XElement af = new XElement("t05", mother.Times[5][0]);
                XElement ba = new XElement("t10", mother.Times[0][1]);
                XElement bb = new XElement("t11", mother.Times[1][1]);
                XElement bc = new XElement("t12", mother.Times[2][1]);
                XElement bd = new XElement("t13", mother.Times[3][1]);
                XElement be = new XElement("t14", mother.Times[4][1]);
                XElement bf = new XElement("t15", mother.Times[5][1]);
                                                                     

                XElement times = new XElement("Times",aa,  ab, ac, ad, ae, af, ba, bb, bc, bd, be, bf);
                XElement days = new XElement("Days", sun, mon, tue, wed, thu, fri, sat);
                XElement hearot = new XElement("Hearot1", mother.Hearot1);


             //   NannyRoot.Add(new XElement("nanny", days, tttt, firstName, lastName, phone, adrress, elevators, birth, flat, experience, maxAge, maxChild, minAge, isHours, moneyForHour, moneyForMonth, id, isTMTVocation, isspecial, recommendation));

                MotherRoot.Add(new XElement("mother", id, firstName, lastName, phone, adrress, babyAdrress, times, days, hearot));
                MotherRoot.Save(motherPath);
           }
        }
        public void ApdateMother(BE.Mother mother)
        {
            XElement xElement =
                  (from item in MotherRoot.Elements()
                   where (Convert.ToString(item.Element("MomId").Value)) == mother.MomId
                   select item).FirstOrDefault();
            if (xElement == null)
                throw new Exception("canot update this mother");
            xElement.Element("MomLastName").Value = mother.MomLastName;
            xElement.Element("MomFirstName").Value = mother.MomFirstName;
            xElement.Element("MomPhone").Value = mother.MomPhone;
            xElement.Element("MomAddress").Value = mother.MomAddress;
            xElement.Element("BabyAddress").Value = mother.BabyAddress;
            //xElement.Element("Times").Value = mother.Times.ToString();
            xElement.Element("Hearot1").Value = mother.Hearot1;
            xElement.Element("Days").Element("mon").Value = mother.Days[1].ToString();
            xElement.Element("Days").Element("tue").Value = mother.Days[2].ToString();
            xElement.Element("Days").Element("wed").Value = mother.Days[3].ToString();
            xElement.Element("Days").Element("thu").Value = mother.Days[4].ToString();
            xElement.Element("Days").Element("fri").Value = mother.Days[5].ToString();
           // xElement.Element("Days").Element("sat").Value = mother.Days[6].ToString();
            xElement.Element("Days").Element("sun").Value = mother.Days[0].ToString();
            xElement.Element("Times").Element("t00").Value = mother.Times[0][0];
            xElement.Element("Times").Element("t01").Value = mother.Times[1][0];
            xElement.Element("Times").Element("t02").Value = mother.Times[2][0];
            xElement.Element("Times").Element("t03").Value = mother.Times[3][0];
            xElement.Element("Times").Element("t04").Value = mother.Times[4][0];
            xElement.Element("Times").Element("t05").Value = mother.Times[5][0];
            xElement.Element("Times").Element("t10").Value = mother.Times[0][1];
            xElement.Element("Times").Element("t11").Value = mother.Times[1][1];
            xElement.Element("Times").Element("t12").Value = mother.Times[2][1];
            xElement.Element("Times").Element("t13").Value = mother.Times[3][1];
            xElement.Element("Times").Element("t14").Value = mother.Times[4][1];
            xElement.Element("Times").Element("t15").Value = mother.Times[5][1];


            MotherRoot.Save(motherPath);
        }
        public void DelMother(BE.Mother temp)
        {
            try
            {
                XElement xElement =
                (from item in MotherRoot.Elements()
                 where (Convert.ToString(item.Element("MomId").Value)) == temp.MomId
                 select item).FirstOrDefault();
                xElement.Remove();
                MotherRoot.Save(motherPath);
            }
            catch
            {
                throw new Exception("canot remove this mother");
            }
        }


        public void AddContract(BE.Contract contract)
        {
            XElement xElement = (from item in contractCodeRoot.Elements()
                                 where (Convert.ToInt16(item.Element("code").Value)) == contract.ContractCode
                                 select item).FirstOrDefault();
            if (xElement != null)
                ApdateContract(contract);
            else
            {
                XElement xcode = (from item in contractCodeRoot.Elements()
                                  where (item.Element("codecode").Value)=="1234"
                                  select item).FirstOrDefault();
                int cc = Convert.ToInt16(xcode.Element("code").Value);
                cc++;
                xcode.Element("code").Value = cc.ToString();
                contractCodeRoot.Save(contractCodePath);
                XElement code = new XElement("ContractCode", cc);
                XElement nannyID = new XElement("NannyID", contract.NannyID);
                XElement childID = new XElement("ChildID", contract.ChildID);
                XElement isMeating = new XElement("IsMeating", contract.IsMeating);
                XElement signing = new XElement("Signing", contract.Signing);
                XElement payForHour = new XElement("PayForHour", contract.PayForHour);
                XElement payForMonth = new XElement("PayForMonth", contract.PayForMonth);
                XElement isHour = new XElement("IsHour", contract.IsHour);
                XElement startingDate = new XElement("StartingDate", contract.StartingDate);
                XElement endingDate = new XElement("EndingDate", contract.EndingDate);
                XElement momId = new XElement("MomId", contract.MomId);
             
                ContractRoot.Add(new XElement("contract", code, nannyID, childID, isMeating, signing, payForHour, payForMonth, isHour, startingDate, endingDate, momId));
                ContractRoot.Save(contractPath);
            }
        }
        public void DelContract(BE.Contract temp)
        {
            try
            {
                XElement xElement = (from item in ContractRoot.Elements()
                                     where (Convert.ToInt16(item.Element("ContractCode").Value)) == temp.ContractCode
                                     select item).FirstOrDefault();
                xElement.Remove();
                ContractRoot.Save(contractPath);
            }
            catch
            {
                throw new Exception("canot remove this contract");
            }
        }
        public void ApdateContract(BE.Contract contract)
        {
            XElement xElement = (from item in ContractRoot.Elements()
                                 where (Convert.ToInt16(item.Element("code").Value)) == contract.ContractCode
                                 select item).FirstOrDefault();
            if (xElement == null)
                throw new Exception("canot update this contrac");
            xElement.Element("code").Value = contract.ContractCode.ToString();
            xElement.Element("NannyID").Value = contract.NannyID;
            xElement.Element("ChildID").Value = contract.ChildID;
            xElement.Element("IsMeating").Value = contract.IsMeating.ToString();
            xElement.Element("Signing").Value = contract.Signing.ToString();
            xElement.Element("PayForHour").Value = contract.PayForHour.ToString();
            xElement.Element("PayForMonth").Value = contract.PayForMonth.ToString();
            xElement.Element("IsHour").Value = contract.IsHour.ToString();
            xElement.Element("StartingDate").Value = contract.StartingDate.ToString();
            xElement.Element("EndingDate").Value = contract.EndingDate.ToString();
            xElement.Element("MomId").Value = contract.MomId;
          
            ContractRoot.Save(contractPath);
        }


        public IEnumerable<BE.Child> SearchChild(Func<BE.Child, bool> func)
        {
            IEnumerable<BE.Child> temp = from item in ChilRoot.Elements()
                                         where func(this.ChildFromElement(item))
                                         select ChildFromElement(item);
            return temp;
            
        }
        

        public BE.Contract ContractFromElemnt(XElement xElement)
        {
            BE.Contract temp = new BE.Contract();
            temp.ContractCode = Convert.ToInt32(xElement.Element("ContractCode").Value);
            temp.MomId = xElement.Element("MomId").Value;
            temp.NannyID = xElement.Element("NannyID").Value;
            temp.ChildID = xElement.Element("ChildID").Value;
            temp.EndingDate = Convert.ToDateTime(xElement.Element("EndingDate").Value);
            temp.StartingDate = Convert.ToDateTime(xElement.Element("StartingDate").Value);
            temp.IsHour = Convert.ToBoolean(xElement.Element("IsHour").Value);
            temp.IsMeating = Convert.ToBoolean(xElement.Element("IsMeating").Value);
            temp.Signing = Convert.ToBoolean(xElement.Element("Signing").Value);
            temp.PayForHour = Convert.ToInt32(xElement.Element("PayForHour").Value);
            temp.PayForMonth = Convert.ToInt32(xElement.Element("PayForMonth").Value);



            //foreach (PropertyInfo item in typeof(BE.Contract).GetProperties())
            //{
            //    TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
            //    object convertValue = typeConverter.ConvertFromString(xElement.Element(item.Name).Value);

            //    if (item.CanWrite)
            //        item.SetValue(temp, convertValue);
            //}
            return temp;

        }
        public BE.Mother MotherFromElemnt(XElement xElement)
        {
            BE.Mother temp = new BE.Mother();
            temp.Times[0] = new string[2];
            temp.Times[1] = new string[2];
            temp.Times[2] = new string[2];
            temp.Times[3] = new string[2];
            temp.Times[4] = new string[2];
            temp.Times[5] = new string[2];
            temp.MomId = xElement.Element("MomId").Value;
            temp.BabyAddress = xElement.Element("BabyAddress").Value;
            temp.Hearot1 = xElement.Element("Hearot1").Value;
            temp.MomAddress = xElement.Element("MomAddress").Value;
            temp.MomFirstName = xElement.Element("MomFirstName").Value;
            temp.MomLastName = xElement.Element("MomLastName").Value;
            temp.MomPhone = xElement.Element("MomPhone").Value;
            temp.Days[0] = Convert.ToBoolean(xElement.Element("Days").Element("sun").Value);
            temp.Days[1] = Convert.ToBoolean(xElement.Element("Days").Element("mon").Value);
            temp.Days[2] = Convert.ToBoolean(xElement.Element("Days").Element("tue").Value);
            temp.Days[3] = Convert.ToBoolean(xElement.Element("Days").Element("wed").Value);
            temp.Days[4] = Convert.ToBoolean(xElement.Element("Days").Element("thu").Value);
            temp.Days[5] = Convert.ToBoolean(xElement.Element("Days").Element("fri").Value);
           // temp.Days[6] = Convert.ToBoolean(xElement.Element("Days").Element("sat").Value);
            temp.Times[0][0] = xElement.Element("Times").Element("t00").Value;
            temp.Times[1][0] = xElement.Element("Times").Element("t01").Value;
            temp.Times[2][0] = xElement.Element("Times").Element("t02").Value;
            temp.Times[3][0] = xElement.Element("Times").Element("t03").Value;
            temp.Times[4][0] = xElement.Element("Times").Element("t04").Value;
            temp.Times[5][0] = xElement.Element("Times").Element("t05").Value;
            temp.Times[0][1] = xElement.Element("Times").Element("t10").Value;
            temp.Times[1][1] = xElement.Element("Times").Element("t11").Value;
            temp.Times[2][1] = xElement.Element("Times").Element("t12").Value;
            temp.Times[3][1] = xElement.Element("Times").Element("t13").Value;
            temp.Times[4][1] = xElement.Element("Times").Element("t14").Value;
            temp.Times[5][1] = xElement.Element("Times").Element("t15").Value;




            return temp;
        }
        public BE.Nanny NannyFromElement(XElement xElement)
        {
            BE.Nanny temp = new BE.Nanny();
            temp.Times = new string[6][];
            temp.Times[0] = new string[2];
            temp.Times[1] = new string[2];
            temp.Times[2] = new string[2];
            temp.Times[3] = new string[2];
            temp.Times[4] = new string[2];
            temp.Times[5] = new string[2];
    //temp.Image = xElement.Element("Image").Value;
            temp.IsElevators = Convert.ToBoolean(xElement.Element("IsElevators").Value);
            temp.IsHours = Convert.ToBoolean(xElement.Element("IsHours").Value);
            temp.Isspecial = Convert.ToBoolean(xElement.Element("Isspecial").Value);
            temp.IsTMTVocation = Convert.ToBoolean(xElement.Element("IsTMTVocation").Value);
            temp.MaxAge = Convert.ToInt16(xElement.Element("MaxAge").Value);
            temp.MaxChild = Convert.ToInt16(xElement.Element("MaxChild").Value);
            temp.MinAge = Convert.ToInt16(xElement.Element("MinAge").Value);
            temp.MoneyForHour = Convert.ToDouble(xElement.Element("MoneyForHour").Value);
            temp.MoneyForMonth = Convert.ToDouble(xElement.Element("MoneyForMonth").Value);
            temp.NannyAddress = xElement.Element("NannyAddress").Value;
            temp.NannyBirth = Convert.ToDateTime(xElement.Element("NannyBirth").Value);
            temp.NannyExperience = Convert.ToInt16(xElement.Element("NannyExperience").Value);
            temp.NannyFirstName = xElement.Element("NannyFirstName").Value;
            temp.Nannyflat = Convert.ToInt16(xElement.Element("Nannyflat").Value);
            temp.NannyId = xElement.Element("NannyId").Value;
            temp.NannyLastName = xElement.Element("NannyLastName").Value;
            temp.NannyPhone = xElement.Element("NannyPhone").Value;
            temp.Recommendation = xElement.Element("Recommendation").Value;

            temp.Days[0] = Convert.ToBoolean(xElement.Element("Days").Element("sun").Value);
            temp.Days[1] = Convert.ToBoolean(xElement.Element("Days").Element("mon").Value);
            temp.Days[2] = Convert.ToBoolean(xElement.Element("Days").Element("tue").Value);
            temp.Days[3] = Convert.ToBoolean(xElement.Element("Days").Element("wed").Value);
            temp.Days[4] = Convert.ToBoolean(xElement.Element("Days").Element("thu").Value);
            temp.Days[5] = Convert.ToBoolean(xElement.Element("Days").Element("fri").Value);
            string y = xElement.Element("Times").Element("t01").Value;
            temp.Times[0][0] = xElement.Element("Times").Element("t00").Value;
            temp.Times[1][0] = xElement.Element("Times").Element("t01").Value;
            temp.Times[2][0] = xElement.Element("Times").Element("t02").Value;
            temp.Times[3][0] = xElement.Element("Times").Element("t03").Value;
            temp.Times[4][0] = xElement.Element("Times").Element("t04").Value;
            temp.Times[5][0] = xElement.Element("Times").Element("t05").Value;
            temp.Times[0][1] = xElement.Element("Times").Element("t10").Value;
            temp.Times[1][1] = xElement.Element("Times").Element("t11").Value;
            temp.Times[2][1] = xElement.Element("Times").Element("t12").Value;
            temp.Times[3][1] = xElement.Element("Times").Element("t13").Value;
            temp.Times[4][1] = xElement.Element("Times").Element("t14").Value;
            temp.Times[5][1] = xElement.Element("Times").Element("t15").Value;



            return temp;

        }

        public IEnumerable<BE.Mother> SearchMother(Func<BE.Mother, bool> func)
        {
            IEnumerable<BE.Mother> mother;
            mother = from item in MotherRoot.Elements()
                     where (func(MotherFromElemnt(item)))
                     select MotherFromElemnt(item);
            return mother;

        }
        public IEnumerable<BE.Contract> SearchContract(Func<BE.Contract, bool> func)
        {
          //BE.Contract
            IEnumerable<BE.Contract> contract = from item in ContractRoot.Elements()
                                                where (func(ContractFromElemnt(item)))
                                                select ContractFromElemnt(item);
            //  IEnumerable<BE.Contract> t = from item in contractCodeRoot.Elements() select contract;
            return contract;
           
        }
        public IEnumerable<BE.Nanny> SearchNany(Func<BE.Nanny, bool> predicatt)
        {
            IEnumerable<BE.Nanny> nanny = from item in NannyRoot.Elements()
                                          where predicatt(NannyFromElement(item))
                                          select NannyFromElement(item);
            return nanny;
        }

        public List<BE.Nanny> GetNannyList()
        {
            List<BE.Nanny> nanny = new List<BE.Nanny>();
            foreach (XElement item in NannyRoot.Elements())
                nanny.Add(NannyFromElement(item));
            return nanny;
        }
        public List<BE.Mother> GetMotherList()
        {

            List<BE.Mother> mother = new List<BE.Mother>();
            foreach (XElement item in MotherRoot.Elements())
                mother.Add(MotherFromElemnt(item));
            return mother;
        }
        public List<BE.Child> GetChildMothers(string id)
        {
            List<BE.Child> child = new List<BE.Child>();
            foreach (XElement item in ChilRoot.Elements())
            {
                if(item.Element("MomId").Value==id)
                child.Add(ChildFromElement(item));
            }
            return child;
        }
        public List<BE.Child> GetChildList()
        {
            List<BE.Child> child = new List<BE.Child>();
            foreach (XElement item in ChilRoot.Elements())
            {

                child.Add(ChildFromElement(item));
            }
            return child;
        }

        public List<BE.Contract> GetCOntracts()
        {
            List<BE.Contract> contract = new List<BE.Contract>();
            foreach (XElement item in ContractRoot.Elements())
                contract.Add(ContractFromElemnt(item));
            return contract;
        }


        public List<BE.Contract> ContractNanny(string id)
        {
            List<BE.Contract> listContract = new List<BE.Contract>();
            foreach (XElement item in ContractRoot.Elements())
            {
                if (ContractFromElemnt(item).NannyID == id)
                    listContract.Add(ContractFromElemnt(item));
            }
            return listContract;
        }
        public List<BE.Child> MomChildAtNany(string momid, string nanyid)
        {
            List<BE.Child> childList = new List<BE.Child>();
            BE.Contract contract;
            foreach (XElement item in ContractRoot.Elements())
            {
                contract = ContractFromElemnt(item);
                if (contract.MomId == momid && contract.NannyID == nanyid)
                    childList.Add(SearchChild(x => x.ChildId == contract.ChildID).FirstOrDefault());
            }
            return childList;
        }
        public IEnumerable<BE.Contract> SearchContantByChildId(string id)
        {
            IEnumerable<BE.Contract> contract = from item in ContractRoot.Elements()
                                                where ContractFromElemnt(item).ChildID == id
                                                select ContractFromElemnt(item);
            return contract;

        }

        public IEnumerable<string> Nomid()
        {
            return from item in MotherRoot.Elements()
                   select item.Element("MomId").ToString();
        }

    }
}
