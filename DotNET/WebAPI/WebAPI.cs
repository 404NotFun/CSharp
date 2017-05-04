using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using SysAPI.Models;

namespace SysAPI.Controllers
{
    public class AuthAPIController : ApiController
    {
        static readonly IMemberRepository _memberRepository = new MemberRepository();

		[HttpGet]
        [Route("api/getMembers/")]
        // 取得所有人員
		public IEnumerable<Member> GetAllMembers()
		{
			return _memberRepository.GetAll();
		}

		[HttpPut]
        [Route("api/auth/refreshDeviceToken/{id}")]
        // 更新Device Token
        public IHttpActionResult refreshDeviceToken(string id, [FromBody] Member item)
		{
            if (item == null || item.id != id)
			{
                return BadRequest();
			}

			var member = _memberRepository.Get(id);
			if (member == null)
			{
			    return NotFound();
			}
            member = item;
            _memberRepository.Update(member);

            return Ok(member);
		}

        [HttpPost]
        [Route("api/auth/checkCode")]
        // 驗證碼驗證
        public IHttpActionResult CheckCode(Member item)
        {
            
            return Ok(item);
        }

		[HttpPost]
		[Route("api/auth/login")]
		// 登入
		public IHttpActionResult Login(Member item)
		{
			return Ok(item);
		}
	}
}
