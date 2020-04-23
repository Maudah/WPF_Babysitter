using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class All : IBL
    {



        public delegate bool SomeDele(BE.Nanny nanny);
        public delegate bool SomeDel2(BE.Child child);
        DAL.Idal dimp;
        public enum TravelType
        {
            Walking,
            Driving
        }
        static string API_KEY = ConfigurationSettings.AppSettings.Get("googleApiKey");
        public All()
        {
            dimp = DAL.Factory.GetDal();
        }
        public void AddNanny(BE.Nanny nanny)

        {

            if (WhatAge(nanny.NannyBirth) < 18)
            {
                throw new Exception("canot add young nanny");
            }
            else
                dimp.AddNanny(nanny);
        }



        public void DelNanny(string id)
        {
            IEnumerable<BE.Contract> contract = dimp.SearchContract(x => x.NannyID== id);
            if (contract.Count() != 0)
                throw new Exception("canot delete this nanny you have to remove this contract :" + contract.Last().ContractCode);
            dimp.DelNanny(dimp.SearchNany(x => x.NannyId == id).Last());
        }
        public void ApdateNanny(BE.Nanny nanny) { dimp.ApdateNanny(nanny); }
        public void AddMother(BE.Mother mother) { dimp.AddMother(mother); }
        public void ApdateMother(BE.Mother mother) { dimp.ApdateMother(mother); }
        public void DelMother(string id)
        {
            IEnumerable<BE.Contract> contract = dimp.SearchContract(x => x.MomId == id);
            if (contract.Count() != 0)
                throw new Exception("canot delete this mother you have to remove this contract :" + contract.Last().ContractCode);

            dimp.DelMother(dimp.SearchMother(x => x.MomId == id).Last());
        }
        public void AddChild(BE.Child child)
        {
            if (dimp.SearchMother(x => x.MomId == child.MomId) == null)
                throw new Exception("we dont find your mother ");
            dimp.AddChild(child);
        }
        public void ApdateChild(BE.Child child) { dimp.ApdateChild(child); }
        public void DelChild(string id)
        {
            IEnumerable<BE.Contract> contract = dimp.SearchContract(x => x.ChildID == id);
            if (contract != null)
                throw new Exception("canot delete this child you have to remove this contract :" + contract.Last().ContractCode);

            dimp.DelChild(dimp.SearchChild(x => x.ChildId == id).Last());
        }
        public void AddContract(BE.Contract contract)
        {
            bool flag;
            int counter = 0;
            BE.Nanny nannytemp = dimp.SearchNany(x => x.NannyId == contract.NannyID).FirstOrDefault();
            BE.Mother mothertemp = dimp.SearchMother(x => x.MomId == contract.MomId).FirstOrDefault();
            BE.Child childtemp = dimp.SearchChild(x => x.ChildId == contract.ChildID).FirstOrDefault();
            if (nannytemp == null || mothertemp == null || childtemp == null || (nannytemp.Isspecial == false && childtemp.SpecialBoy == true))
                throw new Exception("וודא שהיקשת ת.ז נכונים עבור אמא ילד ומטפלת!");
            IEnumerable<BE.Contract> tt = dimp.SearchContract(x => x.NannyID == contract.NannyID);
            if (WhatAge(childtemp.ChildBirth) < nannytemp.MinAge|| WhatAge(childtemp.ChildBirth) <0.3 || WhatAge(childtemp.ChildBirth) > nannytemp.MaxAge)
                throw new Exception("canot add this contract! ");
           
            else
            {
                 flag = false;
                for (int i = 0; i < 6; i++)
                {
                    if (nannytemp.Days[i] == false && mothertemp.Days[i] == true)
                        flag = false;
                    else//need this day
                    {
                        if (mothertemp.Days[i] == true&& nannytemp.Days[i] == true)
                        {
                            if (this.HoursStart(i, mothertemp) > this.HoursStart(i, nannytemp))//שעת התחלה מוקדמת מהרצוי
                            {
                                if ((this.HourEnd(i, mothertemp) < this.HourEnd(i, nannytemp)) || (this.HourEnd(i, mothertemp) == this.HourEnd(i, nannytemp) && this.MinutesEnd(i, mothertemp) <= this.MinutesEnd(i, nannytemp)))//שעת סיום מאוחרת מהרצוי
                                    flag = true;
                            }
                            //שעת התחלה שווה לרצוי
                            if (this.HoursStart(i, mothertemp) == this.HoursStart(i, nannytemp) && (this.MinutesStart(i, mothertemp) <= MinutesStart(i, nannytemp)))
                            {
                                if ((this.HourEnd(i, mothertemp) < this.HourEnd(i, nannytemp)) || (this.HourEnd(i, mothertemp) == this.HourEnd(i, nannytemp) && this.MinutesEnd(i, mothertemp) <= this.MinutesEnd(i, nannytemp)))//שעת סיום מאוחרת מהרצוי
                                    flag = true;
                            }
                        }
                    }
                    if (flag == false)
                        i = 6;
                }
            }
            if (flag==true)
            {
                double netopay;
                List<BE.Child> listchild = dimp.MomChildAtNany(contract.MomId, contract.NannyID);
                int numofchild = listchild.Count;
                if (nannytemp.IsHours)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (mothertemp.Days[i])
                        {

                            int minstart = MinutesStart(i, mothertemp);
                            int hourstart = this.HoursStart(i, mothertemp);
                            int timestart = hourstart * 60 + minstart;
                            int minend = this.MinutesEnd(i, mothertemp);
                            int hourend = this.HourEnd(i, mothertemp);
                            int timeend = hourstart * 60 + minstart;

                            counter += timeend - timestart;
                        }
                    }
                    netopay = nannytemp.MoneyForHour * 0.16666667 * counter * 4;

                }
                else
                {
                    netopay = nannytemp.MoneyForMonth;
                }
                for (int i = 0; i < numofchild; i++)
                    netopay *= 0.8;
                contract.PayForMonth = netopay;
                dimp.AddContract(contract);
            }
        
        }

        public void ApdateContract(BE.Contract contract) { dimp.ApdateContract(contract); }
        public void DelContract(BE.Contract temp)
        {
            if (temp.EndingDate > DateTime.Now)
                throw new Exception("contract time didny over");
            dimp.DelContract(temp);
        }
        public List<BE.Nanny> GetNannyList() { return dimp.GetNannyList(); }
        public List<BE.Mother> GetMotherList() { return dimp.GetMotherList(); }
        public List<BE.Child> GetChildMothers(string id) { return dimp.GetChildMothers(id); }
        public List<BE.Contract> GetCOntracts() { return dimp.GetCOntracts(); }
        public double WhatAge(DateTime dt)
        {
            int age = 0;
            while (dt.AddMonths(age) < DateTime.Now)
            {
                age++;
            }
            double x= age / 12 + (age % 12)*0.1;
            return x;
        }
        //public double LengthInAdrress(string ad1,string ad2)
        //{
        //    return GoogleMapsApi.GoogleMaps.
        //}

        public List<BE.Nanny> PotentionNanny(BE.Child child)
        {
            if (child == null)
                throw new Exception("הילד המבוקש לא נימצא!");
            BE.Mother motherDetails = new BE.Mother();
            motherDetails = SearchMother(x => x.MomId == child.MomId).FirstOrDefault();
            List<BE.Nanny> templist = new List<BE.Nanny>();
            List<BE.Nanny> allnanny = this.GetNannyList();
            bool flag = false;
            foreach (BE.Nanny item in allnanny)
            {
                flag = false;
                for (int i = 0; i < 6; i++)
                {
                    if (item.Days[i] == false && motherDetails.Days[i] == true||(item.MaxAge < WhatAge(child.ChildBirth) || item.MinAge > WhatAge(child.ChildBirth)))
                        flag = false;
                    
                    if(motherDetails.Days[i]==true&&item.Days[i]==true)//need this day
                    {
                        if (this.HoursStart(i, motherDetails) > this.HoursStart(i, item) || (this.HoursStart(i, motherDetails) == this.HoursStart(i, item) && (this.MinutesStart(i, motherDetails) <= MinutesStart(i, item))))//שעת התחלה מוקדמת מהרצוי
                        {
                            if ((this.HourEnd(i, motherDetails) < this.HourEnd(i, item)) || (this.HourEnd(i, motherDetails) == this.HourEnd(i, item) && this.MinutesEnd(i, motherDetails) <= this.MinutesEnd(i, item)))//שעת סיום מאוחרת מהרצוי
                                flag = true;
                        }
                        else flag = false;
                        ////שעת התחלה שווה לרצוי
                        //if (this.HoursStart(i, motherDetails) == this.HoursStart(i, item) && (this.MinutesStart(i, motherDetails) <= MinutesStart(i, item)))
                        //{
                        //    if ((this.HourEnd(i, motherDetails) < this.HourEnd(i, item)) || (this.HourEnd(i, motherDetails) == this.HourEnd(i, item) && this.MinutesEnd(i, motherDetails) <= this.MinutesEnd(i, item)))//שעת סיום מאוחרת מהרצוי
                        //        flag = true;
                        //}
                    }
                    if (flag == false)
                        i = 6;
                }
                if (flag)
                    templist.Add(item);
            }
            
            return templist;
        }
        //חמש מטפלות שמשחררות את הילד  שעה מוקדם יותר ממה שהאם צריכה
        public List<BE.Nanny> FivePotentionNanny(BE.Child child)
        {
            if (child == null)
                throw new Exception("הילד המבוקש לא נימצא!");
            BE.Mother motherDetails = new BE.Mother();
            motherDetails = SearchMother(x => x.MomId == child.MomId).FirstOrDefault();
            List<BE.Nanny> templist = new List<BE.Nanny>();
            List<BE.Nanny> allnanny = this.GetNannyList();
            bool flag = false;
            foreach (BE.Nanny item in allnanny)
            {
                flag = false;
                for (int i = 0; i < 6; i++)
                {
                    if (item.Days[i] == false && motherDetails.Days[i] == true || (item.MaxAge < WhatAge(child.ChildBirth) || item.MinAge > WhatAge(child.ChildBirth)))
                        flag = false;

                    if (motherDetails.Days[i] == true && item.Days[i] == true)//need this day
                    {
                        if (this.HoursStart(i, motherDetails) > this.HoursStart(i, item) || (this.HoursStart(i, motherDetails) == this.HoursStart(i, item) && (this.MinutesStart(i, motherDetails) <= MinutesStart(i, item))))//שעת התחלה מוקדמת מהרצוי
                        {
                            if ((this.HourEnd(i, motherDetails) < this.HourEnd(i, item)+1) || (this.HourEnd(i, motherDetails) == this.HourEnd(i, item)+1 && this.MinutesEnd(i, motherDetails) <= this.MinutesEnd(i, item)))//שעת סיום מאוחרת מהרצוי
                                flag = true;
                        }
                        else flag = false;
                        ////שעת התחלה שווה לרצוי
                        //if (this.HoursStart(i, motherDetails) == this.HoursStart(i, item) && (this.MinutesStart(i, motherDetails) <= MinutesStart(i, item)))
                        //{
                        //    if ((this.HourEnd(i, motherDetails) < this.HourEnd(i, item)) || (this.HourEnd(i, motherDetails) == this.HourEnd(i, item) && this.MinutesEnd(i, motherDetails) <= this.MinutesEnd(i, item)))//שעת סיום מאוחרת מהרצוי
                        //        flag = true;
                        //}
                    }
                    if (flag == false)
                        i = 6;
                }
                if (flag)
                    templist.Add(item);
            }

            return templist;
            //BE.Mother motherDetails = new BE.Mother();
            //motherDetails = SearchMother(x => x.MomId == child.MomId).FirstOrDefault();
            //List<BE.Nanny> templist = new List<BE.Nanny>();
            //List<BE.Nanny> allnanny = this.GetNannyList();
            //bool flag = false;
            //foreach (BE.Nanny item in allnanny)
            //{
            //    flag = false;
            //    for (int i = 0; i < 6; i++)
            //    {
            //        if (item.Days[i] == false && motherDetails.Days[i] == true || (item.MaxAge < WhatAge(child.ChildBirth) || item.MinAge > WhatAge(child.ChildBirth)))
            //            flag = false;
            //        else//need this day
            //          if (this.HoursStart(i, motherDetails) > this.HoursStart(i, item) || (this.HoursStart(i, motherDetails) == this.HoursStart(i, item) && (this.MinutesStart(i, motherDetails) <= MinutesStart(i, item))))
            //            flag = true;
            //        if (flag == false)
            //            i = 6;
            //    }
            //    if (flag)
            //        templist.Add(item);
            //}
            //List<BE.Nanny> fivebest = new List<BE.Nanny>();
            //for (int j = 0; j < 5; j++)
            //{
            //    BE.Nanny bestNanny = templist.First();
            //    foreach (BE.Nanny item in templist)
            //    {
            //        for (int i = 0; i < 6; i++)
            //        {
            //            int nannyMinEnd = MinutesEnd(i, item), nannyHend = HourEnd(i, item);
            //            if (this.HourEnd(i, bestNanny) < nannyHend || (HourEnd(i, bestNanny) == nannyHend && MinutesEnd(i, bestNanny) < nannyMinEnd))
            //                bestNanny = item;
            //        }
            //    }
            //    fivebest.Add(bestNanny);
            //    templist.Remove(bestNanny);
            //}

            //return fivebest;
        }
        public List<BE.Child> ChildWithoutNanny()
        {
            List<BE.Child> listChild = new List<BE.Child>();

            List<BE.Child> AllChild = dimp.GetChildList();
            foreach (BE.Child item in AllChild)
            {
                if (dimp.SearchContantByChildId(item.ChildId).Count() == 0)
                    listChild.Add(item);
            }
            return listChild;
        }
        public List<BE.Nanny> TMTNanny()
        {
            List<BE.Nanny> list = new List<BE.Nanny>();
            List<BE.Nanny> allnanny = dimp.GetNannyList();
            foreach (BE.Nanny item in allnanny)
                if (item.IsTMTVocation == true)
                    list.Add(item);
            return list;
        }
        public delegate bool MyDel(BE.Contract cc);
        public List<BE.Contract> ContantDelegate(MyDel myDel)
        {
            List<BE.Contract> list = new List<BE.Contract>();
            List<BE.Contract> allcontant = dimp.GetCOntracts();
            foreach (BE.Contract item in allcontant)
                if (myDel(item) == true)
                    list.Add(item);
            return list;
        }
        public int CountContantDelegate(MyDel myDel)
        {
            int count = 0;
            List<BE.Contract> allcontant = dimp.GetCOntracts();
            foreach (BE.Contract item in allcontant)
                if (myDel(item) == true)
                    count++;
            return count;
        }
        public IEnumerable<IGrouping<int, BE.Nanny>> NannyByChildAge(bool ismax , bool isorder )
        {
            List<BE.Nanny> nannytlist = dimp.GetNannyList();
            if (ismax == true)
            {
                if (isorder == true)
                {
                    var function = from temp in nannytlist
                                   group temp by temp.MaxAge into newgroup
                                   orderby newgroup.Key
                                   select newgroup;

                    return function;

                }
                else
                {
                    var function = from temp in nannytlist
                                   group temp by temp.MaxAge into newgroup
                                   select newgroup;

                    return function;
                }
            }
            else
            {
                if (isorder == true)
                {
                    var function = from temp in nannytlist
                                   group temp by temp.MinAge into newgroup
                                   orderby newgroup.Key
                                   select newgroup;
                    return function;
                }
                else
                {
                    var function = from temp in nannytlist
                                   group temp by temp.MinAge into newgroup
                                   select newgroup;
                    return function;
                }
            }

        }
        public int HoursStart(int i, BE.Mother mothertemp)//מחזירה שעת התחלה
        {

            int x = (int)((mothertemp.Times[0][i])[0]);
            int y = (int)((mothertemp.Times[0][i])[1]);
            return x * 10 + y;

        }
        public int MinutesStart(int i, BE.Mother mothertemp)//מחזירה דקות התחלה
        {
            int x = (int)((mothertemp.Times[0][i])[4]);
            int y = (int)((mothertemp.Times[0][i])[3]);
            return y * 10 + x;
        }
        public int HourEnd(int i, BE.Mother mothertemp)//מחזירה שעות סיום
        {
            int x = (int)((mothertemp.Times[1][i])[0]);
            int y = (int)((mothertemp.Times[1][i])[1]);
            return x * 10 + y;
        }
        public int MinutesEnd(int i, BE.Mother mothertemp)//מחזירה דקות סיום
        {
            int x = (int)((mothertemp.Times[1][i])[4]);
            int y = (int)((mothertemp.Times[1][i])[3]);
            return y * 10 + x;
        }
        public int HoursStart(int i, BE.Nanny mothertemp)//מחזירה שעת התחלה
        {

            int x = (int)((mothertemp.Times[0][i])[0]);
            int y = (int)((mothertemp.Times[0][i])[1]);
            return x * 10 + y;

        }
        public int MinutesStart(int i, BE.Nanny mothertemp)//מחזירה דקות התחלה
        {
            int x = (int)((mothertemp.Times[0][i])[4]);
            int y = (int)((mothertemp.Times[0][i])[3]);
            return y * 10 + x;
        }
        public int HourEnd(int i, BE.Nanny mothertemp)//מחזירה שעות סיום
        {
            int x = (int)((mothertemp.Times[1][i])[0]);
            int y = (int)((mothertemp.Times[1][i])[1]);
            return x * 10 + y;
        }
        public int MinutesEnd(int i, BE.Nanny mothertemp)//מחזירה דקות סיום
        {
            int x = (int)((mothertemp.Times[1][i])[4]);
            int y = (int)((mothertemp.Times[1][i])[3]);
            return y * 10 + x;
        }
        public static List<string> GetPlaceAutoComplete(string str)
        {
            List<string> result = new List<string>();
            GoogleMapsApi.Entities.PlaceAutocomplete.Request.PlaceAutocompleteRequest request = new GoogleMapsApi.Entities.PlaceAutocomplete.Request.PlaceAutocompleteRequest();
            request.ApiKey = API_KEY;
            request.Input = str;

            var response = GoogleMaps.PlaceAutocomplete.Query(request);

            foreach (var item in response.Results)
            {
                result.Add(item.Description);
            }

            return result;
        }

        public static int CalcDistance(string source, string dest, TravelType travelType)
        {
            Leg leg = null;
            try
            {
                var drivingDirectionRequest = new DirectionsRequest
                {
                    TravelMode = travelType == TravelType.Walking ? TravelMode.Walking : TravelMode.Driving,
                    Origin = source,
                    Destination = dest,
                };

                DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
                Route route = drivingDirections.Routes.First();
                leg = route.Legs.First();
                return leg.Distance.Value;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static TimeSpan CalcDuration(string source, string dest, TravelType travelType)
        {
            Leg leg = null;
            try
            {
                var drivingDirectionRequest = new DirectionsRequest
                {
                    TravelMode = travelType == TravelType.Walking ? TravelMode.Walking : TravelMode.Driving,
                    Origin = source,
                    Destination = dest,
                };

                DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
                Route route = drivingDirections.Routes.First();
                leg = route.Legs.First();
                return leg.Duration.Value;
            }
            catch (Exception)
            {
                return default(TimeSpan);
            }
        }
        public IEnumerable<IGrouping<int, BE.Contract>> ContratGroupingByDistance()
        {

            List<BE.Contract> contractList = dimp.GetCOntracts();
            IEnumerable<IGrouping<int, BE.Contract>> temp;
            temp = from item in contractList
                   group item by CalcDistance((dimp.SearchNany(x => x.NannyId == item.NannyID)).Last().NannyAddress, dimp.SearchMother(x => x.MomId == item.MomId).Last().BabyAddress, TravelType.Walking) / 10
                   into newgroup
                   orderby newgroup.Key
                   select newgroup;
            return temp;
        }
        //מטפלות שמטפלות בילדים עם חינוך מיוחד
        public IEnumerable<BE.Nanny> NannyForSpacialNeeds()
        {
            SomeDele mysomeDele = (nnn) => nnn.Isspecial == true;
            List<BE.Nanny> listnanny = dimp.GetNannyList();
            IEnumerable<BE.Nanny> temp = from item in listnanny
                                         where mysomeDele(item)
                                         select item;
            return temp;
        }
        //ילדים בעלי צרכים מיחדים
        public IEnumerable<BE.Child> ChildWithSpacialNeeds()
        {
            List<BE.Child> childList = dimp.GetChildList();
            SomeDel2 someDel2 = (child) => child.SpecialBoy == true;
            IEnumerable<BE.Child> temp = from item in childList
                                         where someDel2(item)
                                         select item;
            return temp;

        }
        public IEnumerable<BE.Nanny> SearchNany(Func<BE.Nanny, bool> predicatt)
        {
            return dimp.SearchNany(predicatt);
        }
        public IEnumerable<string> Nomid()
        {
            return dimp.Nomid();
        }
        public IEnumerable<BE.Child> SearchChild(Func<BE.Child, bool> func) { return dimp.SearchChild(func); }
        public IEnumerable<BE.Mother> SearchMother(Func<BE.Mother, bool> func) { return dimp.SearchMother(func); }
        public IEnumerable<BE.Contract> SearchContract(Func<BE.Contract, bool> func) { return dimp.SearchContract(func); }
    }
}
