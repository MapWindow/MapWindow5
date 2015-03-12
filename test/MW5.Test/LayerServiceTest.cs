using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Services;
using MW5.Services.Services;
using MW5.Services.Services.Abstract;
using NUnit.Framework;

namespace MW5.Test
{
    [TestFixture]
    public class LayerServiceTest
    {
        //TODO: setup the location of data
        private const string DataPath = @"d:\data\sf\";

        private Mock<IAppContext> _context;
        private Mock<IMessageService> _messageService;
        private Mock<LegendLayerCollection<ILayer>> _layerColection;

        private string[] GetShapefileNames()
        {
            string[] filenames = { @"buildings.shp", @"landuse.shp", @"natural.shp" };
            for (int i = 0; i < filenames.Count(); i++)
            {
                filenames[i] = DataPath + filenames[i];
            }
            return filenames;
        }

        [SetUp]
        public void Setup()
        {
            _layerColection = new Mock<LegendLayerCollection<ILayer>>();
            
            var map = new Mock<IMuteMap>();
            map.SetupGet(m => m.Layers).Returns(_layerColection.Object);

            _context = new Mock<IAppContext>();
            _context.SetupGet(c => c.Map).Returns(map.Object);

            _messageService = new Mock<IMessageService>();
        }
        
        [Test]
        public void Test_AddLayer()
        {
            string[] filenames = GetShapefileNames();

            var fileService = new Mock<IFileDialogService>();
            fileService.Setup(s => s.OpenFiles(It.Is<DataSourceType>(t => t == DataSourceType.Vector), out filenames)).Returns(true);

            var layerService = new LayerService(_context.Object, fileService.Object, _messageService.Object);
            layerService.AddLayer(DataSourceType.Vector);

            _messageService.Verify(s => s.Warn(It.IsAny<string>()), Times.Never);
            _layerColection.Verify(l => l.Add(It.IsAny<ILayerSource>(), true), Times.AtLeast(filenames.Count()));
        }
    }
}
