using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.Services.Serialization
{
    [DataContract]
    public class XmlRepository
    {
        private readonly IRepository _repository;

        public XmlRepository(IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;

            Folders = _repository.Folders.ToList();
        }

        [DataMember]
        public List<string> Folders { get; set; }
    }
}
