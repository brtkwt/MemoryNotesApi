using Backend.Dtos;
using Backend.Models;
using Microsoft.Identity.Client;

namespace Backend.Helpers
{
	public static class ListExtensions
	{
		public static ListDto ToListDto(this List list)
		{
			return new ListDto
			{
				Id = list.Id,
				Name = list.Name,
			};
		}

		public static List<ListDto> ToListofListDtos(this ICollection<List> lists)
		{
			return lists.Select(list => list.ToListDto()).ToList();
		}
	}
}
