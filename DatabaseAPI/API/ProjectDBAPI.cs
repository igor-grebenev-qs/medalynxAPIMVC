using System;
using System.Collections.Generic;
using System.Linq;
using MedalynxAPI.Models;

namespace MedalynxAPI
{
    internal class ProjectComparer : IComparer<Project>
    {
        public int Compare(Project x, Project y)
        {
            return y.LastUpdate.CompareTo(x.LastUpdate);
        }
    }

    public class ProjectDBAPI
    {
        // Get project by id
        public Project GetById(string projectId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(projectId, false);
            if (id == Guid.Empty) {
                return null;
            }

            using (var dbContext = new MedialynxDbProjectContext()) {
                string sid = id.ToString("B");
                return dbContext.Project.FirstOrDefault(project => project != null && project.Id == sid);
            }
        }

        public List<Project> Get(string projectId = "{00000000-0000-0000-0000-000000000000}")
        {
            Guid id = Utils.ToGuid(projectId);
            List<Project> projects = new List<Project>();
            using (var dbContext = new MedialynxDbProjectContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    Project project = dbContext.Project.FirstOrDefault(pr => pr != null && pr.Id == sid);
                    projects.Add(project);
                }
                else
                {
                    // Add all project
                    projects.AddRange(dbContext.Project);
                }
            }
            projects.Sort(new ProjectComparer());
            return projects;
        }

        public bool Remove(string projectId)
        {
            Guid id = Utils.ToGuid(projectId);
            using (var dbContext = new MedialynxDbProjectContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    Project project = dbContext.Project.FirstOrDefault(pr => pr != null && pr.Id == sid);
                    if (project != null) {
                        // remove cogorts
                        using (var cogortsContext = new MedialynxDbCohortContext()) {
                            List<Models.Cohort.Cohort> cogorts = cogortsContext.Cohorts.Where(c => c != null && c.ProjectId == sid).ToList();
                            cogorts.ForEach(c => Program.MedialynxData.cohortDBAPI.Remove(c.Id));
                        }
                        
                        dbContext.Project.Remove(project);
                        dbContext.SaveChanges();
                    }
                    return true;
                }
            }
            return false;
        }

        public List<Project> GetAllByTeam(string teamId)
        {
            Guid id = Utils.ToGuid(teamId);
            using (var dbContext = new MedialynxDbProjectContext()) {
                if (id != Guid.Empty)
                {
                    string sid = id.ToString("B");
                    List<Project> projects = dbContext.Project.Where(pr => pr != null && pr.TeamId == sid).ToList();
                    projects.Sort(new ProjectComparer());
                    return projects;
                }
            }
            return new List<Project>();
        }

        public void Add(Project project)
        {
            using (var dbContext = new MedialynxDbProjectContext()) {
                dbContext.Project.Add(project);
                dbContext.SaveChanges();
            }
        }

        public void Update(Project project)
        {
            using (var dbContext = new MedialynxDbProjectContext()) {
                Project existsProject = dbContext.Project.FirstOrDefault(pr => pr != null && pr.Id == project.Id);
                if (existsProject != null)
                {
                    if (Utils.CopyPropertyValues<Project>(project, existsProject))
                    {
                        dbContext.Project.Update(existsProject);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}