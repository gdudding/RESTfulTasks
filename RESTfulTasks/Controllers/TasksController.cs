using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace RESTfulTasks.Models
{
    public class TasksController : ApiController
    {
        private RESTfulTasksContext db = new RESTfulTasksContext();

        // GET: api/Tasks
        // This function returns the full list of tasks.
        [Route("api/Tasks/")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.HttpPut]
        [System.Web.Http.HttpDelete]
        public IQueryable<Task> GetTasks()
        {
            return db.Tasks;
        }

        // GET: api/Tasks/5
        // This function returns the specified task.
        [Route("api/Tasks/{id}")]
        [ResponseType(typeof(Task))]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetTask(int id)
        {
            Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [Route("api/Tasks/{id}")]
        // PUT: api/Tasks/5
        // This function is used to update an existing task, specified by the id.
        [System.Web.Http.HttpPut()]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTask(int id, [FromBody] Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.TaskId)
            {
                return BadRequest();
            }

            db.Entry(task).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tasks
        // This function is used to create a new task.
        [Route("api/Tasks/")]
        [ResponseType(typeof(Task))]
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> PostTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tasks.Add(task);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = task.TaskId }, task);
        }

        // DELETE: api/Tasks/5
        // This function deletes the task specified by id.
        [Route("api/Tasks/{id}")]
        [ResponseType(typeof(Task))]
        [System.Web.Http.HttpDelete]
        public async Task<IHttpActionResult> DeleteTask(int id)
        {
            Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(task);
            await db.SaveChangesAsync();

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return db.Tasks.Count(e => e.TaskId == id) > 0;
        }
    }
}