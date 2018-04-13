using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Data;
using System.Data.Entity;

namespace BusinessAccessLayer.Repository
{
    public class AddressBAL : IAddress
    {

        public List<Address> GetAllAddress()
        {
            using(var _context = new AskUsContext())
            {
                List<Address> addresslist = _context.Addresses.ToList();
                return addresslist;
            }
        }

        public void AddAddress(Address address)
        {
            using(var _context= new AskUsContext())
            {
                _context.Addresses.Add(address);
                _context.SaveChanges();
            }
        }
        public void UpdateAddress(Address address)
        {
            using(var _context= new AskUsContext())
            {
                _context.Entry(address).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
        public Address GetAddressById(int id)
        {
            using(var _context= new AskUsContext())
            {
                Address address = _context.Addresses.Where(x => x.AddressId == id).FirstOrDefault();
                return address;
            }
        }
        public void DeleteAddress(Address address)
        {
            using(var _context= new AskUsContext())
            {
                _context.Addresses.Remove(address);
                _context.SaveChanges();
            }
        }
    }
}
