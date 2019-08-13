using System.Collections.Generic;
using System.Linq;
using Archysoft.Data.Entities;
using Archysoft.Domain.Model.Model.Common;
using Archysoft.Domain.Model.Model.Users;

namespace Archysoft.Domain.Model.Extensions
{
    public static class FilterExtensions
    {
        public static SearchResult<UserGridModel> BaseFilter<T>(this IQueryable<UserGridModel> query, BaseFilter filter)
        {
            var totalCount = query.Count();

            // Pagination
            if (filter.PageIndex.HasValue)
                query = query.Skip(filter.PageIndex.Value * filter.PageSize ?? 10);

            if (filter.PageSize.HasValue)
                query = query.Take(filter.PageSize.Value);

            List<UserGridModel> Data = query.ToList();

            // Ordering
            if (!string.IsNullOrEmpty(filter.OrderBy))
            {
                if (filter.Direction != null)
                {
                    if (filter.Direction == "asc")
                    {
                        if (filter.OrderBy == "id")
                        {
                            Data = Data.OrderBy(u=>u.Id).ToList();
                        }
                        else if (filter.OrderBy == "userName")
                        {
                            Data = Data.OrderBy(u => u.UserName).ToList();
                        }
                        else if (filter.OrderBy == "email")
                        {
                            Data = Data.OrderBy(u => u.Email).ToList();
                        }
                        else if (filter.OrderBy == "firstName")
                        {
                            Data = Data.OrderBy(u => u.FirstName).ToList();
                        }
                        else if (filter.OrderBy == "lastName")
                        {
                            Data = Data.OrderBy(u => u.LastName).ToList();
                        }
                    }
                    else if (filter.Direction == "desc")
                    {
                        if (filter.OrderBy == "id")
                        {
                            Data = Data.OrderByDescending(u => u.Id).ToList();
                        }
                        else if (filter.OrderBy == "userName")
                        {
                            Data = Data.OrderByDescending(u => u.UserName).ToList();
                        }
                        else if (filter.OrderBy == "email")
                        {
                            Data = Data.OrderByDescending(u => u.Email).ToList();
                        }
                        else if (filter.OrderBy == "firstName")
                        {
                            Data = Data.OrderByDescending(u => u.FirstName).ToList();
                        }
                        else if (filter.OrderBy == "lastName")
                        {
                            Data = Data.OrderByDescending(u => u.LastName).ToList();
                        }
                    }
                }
            }

            return new SearchResult<UserGridModel>
            {
                Data = Data,
                Total = totalCount
            };
        }

        public static IQueryable<User> FilterUsers(this IQueryable<User> query, BaseFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Search))
            {
                query = query.Where(x => x.UserName.Contains(filter.GetTrimSearch()) || x.Email.Contains(filter.GetTrimSearch()) || x.UserName.Contains(filter.GetTrimSearch()) || x.Profile.FirstName.Contains(filter.GetTrimSearch()) || x.Profile.LastName.Contains(filter.GetTrimSearch()) || x.Id.ToString().Contains(filter.GetTrimSearch()));
            }

            return query;
        }
    }
}
