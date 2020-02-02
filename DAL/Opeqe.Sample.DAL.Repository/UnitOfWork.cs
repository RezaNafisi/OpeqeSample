using Opeqe.Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Opeqe.Sample.DAL.Repository
{
    public class UnitOfWork
    {
        private GenericRepository<User> _user;
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._user == null)
                {
                    this._user = new GenericRepository<User>();
                }
                return _user;
            }

        }


        private GenericRepository<Request> _request;
        public GenericRepository<Request> RequestRepository
        {
            get
            {
                if (this._request == null)
                {
                    this._request = new GenericRepository<Request>();
                }
                return _request;
            }

        }

        private GenericRepository<Distance> _distance;
        public GenericRepository<Distance> DistanceRepository
        {
            get
            {
                if (this._distance == null)
                {
                    this._distance = new GenericRepository<Distance>();
                }
                return _distance;
            }

        }
    }
}
