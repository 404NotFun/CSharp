using System.Collections.Generic;

namespace SysAPI.Models
{
	public interface IMemberRepository
	{
		Member Add(Member member);
		IEnumerable<Member> GetAll();
		Member Get(string id);
		void Remove(string id);
        bool Update(Member member);
	}
}