using GrupoCiencias.Intranet.CrossCutting.Dto.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Implementations.Extensions
{
    internal static class QueryableExtensions
    {  
        private static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();

        private static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");

        private static readonly FieldInfo QueryModelGeneratorField = QueryCompilerTypeInfo.DeclaredFields.First(x => x.Name == "_queryModelGenerator");

        private static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");

        private static readonly PropertyInfo DatabaseDependenciesField = typeof(Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");
         
        public static IQueryable<T> SortBy<T>(this IQueryable<T> source, string order, string columnOrder)
        {
            if (!string.IsNullOrEmpty(order) && !string.IsNullOrEmpty(columnOrder))
            {
                if (order.ToUpper() == "ASC")
                {
                    return ApplyOrder<T>(source, columnOrder, "OrderBy");
                }
                else
                {
                    return ApplyOrder<T>(source, columnOrder, "OrderByDescending");
                }
            }
            return source;
        }

        public static PaginationResultDto<T> GetPaged<T>(this IQueryable<T> query,
                                       int page, int pageSize) where T : class
        {
            var result = new PaginationResultDto<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();
            result.PageSize = result.Results.Count;

            return result;
        }

        public static async Task<PaginationResultDto<T>> GetPagedAsync<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PaginationResultDto<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = await query.CountAsync()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            //var json = query.Skip(skip).Take(pageSize).ToSql();
            result.Results = await query.Skip(skip).Take(pageSize).AsNoTracking().ToListAsync();
            result.PageSize = result.Results.Count;
            return result;
        }


        private static IOrderedQueryable<T> ApplyOrder<T>(
           IQueryable<T> source,
           string property,
           string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }
    }
}
