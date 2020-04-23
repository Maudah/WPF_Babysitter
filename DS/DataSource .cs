using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{
    public class DataSource
    {
        List<BE.Child> childlist;
        List<BE.Contract> contractList;
        List<BE.Mother> motherList;
        List<BE.Nanny> nannyList;
        protected DataSource()
        {
            childlist = new List<Child>();
            contractList = new List<Contract>();
            motherList = new List<Mother>();
            NannyList = new List<Nanny>();

        }
        protected static DataSource instance = null;

        public List<Child> Childlist { get => childlist; set => childlist = value; }
        public List<Contract> ContractList { get => contractList; set => contractList = value; }
        public List<Mother> MotherList { get => motherList; set => motherList = value; }
        public List<Nanny> NannyList { get => nannyList; set => nannyList = value; }

        public static DataSource GetInstanset()
        {
            if (instance == null)
                instance = new DataSource();
            return instance;
        }
        public void AddChild(BE.Child child)
        {

            childlist.Add(child);
        }
        public void AddNanny(BE.Nanny nanny)
        {
            nannyList.Add(nanny);
        }
        public void AddMother(BE.Mother mother)
        {
            motherList.Add(mother);
        }
        public void AddContract(BE.Contract contract)
        {
            contractList.Add(contract);
        }
        public void RemoveNanny(BE.Nanny nanny)
        {
            this.nannyList.Remove(nanny);
        }
        public void RemoveMother(BE.Mother mother)
        {
            this.motherList.Remove(mother);
        }
        public void RemoveContract(BE.Contract contract)
        {
            IEnumerable<BE.Nanny> nanny = this.SearchNanny(x => x.NannyId == contract.NannyID);
            IEnumerable<BE.Child> child = SearchChild(x => x.ChildId == contract.ChildID);
            IEnumerable<BE.Mother> mother = SearchMother(x => x.MomId == contract.MomId);
            if (nanny != null || mother != null || child != null)
                throw new Exception("canot delete this child");
            this.contractList.Remove(contract);
        }
        public void RemoveChild(BE.Child child)
        {
            this.childlist.Remove(child);
        }
        public IEnumerable<BE.Nanny> SearchNanny(Func<BE.Nanny, bool> predicatt = null)
        {
            if (predicatt == null)
                return nannyList.AsEnumerable();
            return nannyList.Where(predicatt);
        }
        public IEnumerable<BE.Mother> SearchMother(Func<BE.Mother, bool> func)
        {
            if (func == null)
                return motherList.AsEnumerable();
            return motherList.Where(func);
        }
        public IEnumerable<BE.Child> SearchChild(Func<BE.Child, bool> predicatt)
        {
            if (predicatt == null)
                return childlist.AsEnumerable();
            return childlist.Where(predicatt);
        }
        public IEnumerable<BE.Contract> SearchContract(Func<BE.Contract, bool> func)
        {
            if (func == null)
                return contractList.AsEnumerable();
            return contractList.Where(func);

        }
        public List<BE.Child> Childmom(string id)
        {
            List<BE.Child> temp = new List<Child>();
            foreach (BE.Child item in childlist)
            {
                if (item.MomId == id)
                    temp.Add(item);
            }
            return temp;
        }
        public List<BE.Child> MomChildAtNany(string momid, string nanyid)
        {
            List<BE.Child> temp = new List<BE.Child>();
            foreach (BE.Contract item in contractList)
            {
                if (item.MomId == momid && item.NannyID == nanyid)
                {
                    IEnumerable<BE.Child> child;
                    child = this.SearchChild(x => x.ChildId == item.ChildID);
                    temp.Add(child.Last());
                }
            }
            return temp;
        }
        public List<BE.Contract> ContractNanny(string id)
        {
            List<BE.Contract> list = new List<Contract>();
            foreach (BE.Contract item in contractList)
            {
                if (item.NannyID == id)
                    list.Add(item);
            }
            return list;
        }
        public IEnumerable<BE.Contract> ContractChild(string id)
        {

            return SearchContract(x => x.ChildID == id);
        }
        public IEnumerable<string> Nomid()
        {
            return from item in motherList
                   select item.MomId;
        }
    }
}
