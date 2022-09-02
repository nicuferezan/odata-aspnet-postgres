using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataAPI.Entities;

namespace ODataAPI.Controllers
{
    public class ActivityController: ODataController
    {
        private readonly ODataAPI.EntityFramework.ActivityAppContext _db;

        public ActivityController(ODataAPI.EntityFramework.ActivityAppContext dbContext)
        {
            _db = dbContext;
        }

        [HttpGet]
        [EnableQuery(PageSize = 15)]
        public IQueryable<Activity> Get()
        {
            return _db.activity;
        }

        [EnableQuery]
        [HttpGet("Activity/{key}")]
        public IQueryable<Activity> GetList(int key)
        {
            return _db.activity.Where(r => r.activityid.Equals(key));
        }


    }
}
