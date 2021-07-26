using System;

namespace Api.Domain.Models.User
{
    public class UserModel
    {
        private string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }


        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        private DateTime _creatAt;
        public DateTime CreatAt
        {
            get { return _creatAt; }
            set
            {
                _creatAt = value == null ? DateTime.UtcNow : value;
            }
        }

        private int _updatedAt;
        public int UpdateAt
        {
            get { return _updatedAt; }
            set { _updatedAt = value; }
        }

    }
}

