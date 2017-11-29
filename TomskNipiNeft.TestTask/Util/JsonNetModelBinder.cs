using System.IO;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace TomskNipiNeft.TestTask.Util
{
    public class JsonNetModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            controllerContext.HttpContext.Request.InputStream.Position = 0;
            var stream = controllerContext.HttpContext.Request.InputStream;
            var json = new StreamReader(stream, Encoding.UTF8).ReadToEnd();
            return JsonConvert.DeserializeObject(json, bindingContext.ModelType);
        }
    }
}