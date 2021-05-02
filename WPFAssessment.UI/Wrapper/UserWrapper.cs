using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WPFAssessment.Model;

namespace WPFAssessment.UI.Wrapper
{
    public class UserWrapper : ModelWrapper<UserLogin>
    {
        public UserWrapper(UserLogin model) : base(model)
        {

        }
        public int UserLoginId { get { return Model.UserLoginId; } }
        public string FirstName
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }
        public string LastName
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }
        public string EmailID
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.Equals(FirstName, ""))
                    {
                        //AddError(propertyName, "Needs to have at least 1 character");
                        yield return "Needs to have at least 1 character";
                    }
                    break;
            }
        }


    }

}
