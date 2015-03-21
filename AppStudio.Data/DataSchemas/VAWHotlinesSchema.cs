using System;
using System.Collections;
using Newtonsoft.Json;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the VAWHotlinesSchema class.
    /// </summary>
    public class VAWHotlinesSchema : BindableSchemaBase, IEquatable<VAWHotlinesSchema>, ISyncItem<VAWHotlinesSchema>
    {
        private string _name;
        private string _address;
        private string _contact;
        private string _email;
        [JsonProperty("_id")]
        public string Id { get; set; }

 
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
 
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }
 
        public string Contact
        {
            get { return _contact; }
            set { SetProperty(ref _contact, value); }
        }
 
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public override string DefaultTitle
        {
            get { return Name; }
        }

        public override string DefaultSummary
        {
            get { return null; }
        }

        public override string DefaultImageUrl
        {
            get { return null; }
        }

        public override string DefaultContent
        {
            get { return null; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "name":
                        return String.Format("{0}", Name); 
                    case "address":
                        return String.Format("{0}", Address); 
                    case "contact":
                        return String.Format("{0}", Contact); 
                    case "email":
                        return String.Format("{0}", Email); 
                    case "defaulttitle":
                        return DefaultTitle;
                    case "defaultsummary":
                        return DefaultSummary;
                    case "defaultimageurl":
                        return DefaultImageUrl;
                    default:
                        break;
                }
            }
            return String.Empty;
        }

        public bool Equals(VAWHotlinesSchema other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return this.Id == other.Id;
        }

        public bool NeedSync(VAWHotlinesSchema other)
        {

            return this.Id == other.Id && (this.Name != other.Name || this.Address != other.Address || this.Contact != other.Contact || this.Email != other.Email);
        }

        public void Sync(VAWHotlinesSchema other)
        {
            this.Name = other.Name;
            this.Address = other.Address;
            this.Contact = other.Contact;
            this.Email = other.Email;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as VAWHotlinesSchema);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
