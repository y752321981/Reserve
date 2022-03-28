﻿using LibraryReserve.pojo.response;
using Newtonsoft.Json;
using Reserve.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Reserve.manager
{
	public class HttpManager
	{
		private static HttpManager instance;
		private static readonly object SyncRoot = new object();
		public static HttpManager Instance
		{
			get
			{
				if (instance == null)
				{
					lock (SyncRoot)//在同一时刻加了锁的那部分程序只有一个线程可以进入
					{
						instance = instance ?? (instance = new HttpManager());
					}
				}
				return instance;
			}
		}
		HttpClient httpClient;
		public List<string> QueryReserveInfo(string user, string password)
		{
			string token = Login(user, password);
			if (token == null)
			{
				return null;
			}
			else
			{
				return GetReserveInfo(token);
			}
		}


		private HttpManager()
		{
			httpClient = new HttpClient();
		}
		public string Login(string user, string password)
		{
			string token = null;
			string url = $"https://seat.ujn.edu.cn:8443/rest/auth?username={user}&password={password}";
			try
			{
				Task<HttpResponseMessage> response = httpClient.GetAsync(url);
				response.Result.EnsureSuccessStatusCode();
				Task<byte[]> cont = response.Result.Content.ReadAsByteArrayAsync();
				LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(Encoding.UTF8.GetString(cont.Result));
				if (loginResponse.status.Equals("success"))
				{
					token = loginResponse.data.token;
					return token;
				}
				else
                {
					throw new Exception(user + "登录状态" + loginResponse.status);
                }
			}
			catch (Exception ex)
			{
				Debug.Log(ex.Message);
				return null;
			}
		}

		private List<string> GetReserveInfo(string token)
		{
			List<string> reserveInfo = new List<string>();
			string url = $"https://seat.ujn.edu.cn:8443/rest/v2/history/1/10?token={token}";
			try
			{
				Task<HttpResponseMessage> response = httpClient.GetAsync(url);
				response.Result.EnsureSuccessStatusCode();
				Task<byte[]> cont = response.Result.Content.ReadAsByteArrayAsync();
				ReservationResponse reservationResponse = JsonConvert.DeserializeObject<ReservationResponse>(Encoding.UTF8.GetString(cont.Result));
				if (reservationResponse.status.Equals("success"))
				{
					var list = reservationResponse.data.reservations;
					list.ForEach(reservation =>
					{
						if (reservation.date.Equals(DateTime.Now.ToString("yyyy-M-dd")) || reservation.date == DateTime.Now.AddDays(1).ToString("yyyy-M-dd"))
						{
							reserveInfo.Add($"{reservation.loc},{reservation.date},{reservation.begin}-{reservation.end},{reservation.stat}");
						}
					});
					return reserveInfo;
				}
				else
				{
					throw new Exception("获取约座信息失败");
				}
				
			}
			catch (Exception ex)
			{
				Debug.Log(ex.Message);
				return null;
			}
		}



		private int GetRoomId(string token, string roomName)
		{

			try
			{
				DateTime dateTime = DateTime.Now.AddDays(1);
				string url = $"https://seat.ujn.edu.cn:8443/rest/v2/room/stats2/2/{dateTime.Year:D4}-{dateTime.Month:D2}-{dateTime.Day:D2}?token={token}";
				Task<HttpResponseMessage> response = httpClient.GetAsync(url);
				response.Result.EnsureSuccessStatusCode();
				Task<byte[]> cont = response.Result.Content.ReadAsByteArrayAsync();
				RoomResponse roomResponse = JsonConvert.DeserializeObject<RoomResponse>(Encoding.UTF8.GetString(cont.Result));
				if (roomResponse.data.Equals("success"))
				{
					var list = roomResponse.data;
					foreach (var item in list)
					{
						if (item.room == roomName)
						{
							return item.roomId;
						}
					}
					throw new Exception(roomName + "不存在");
				}
				else
				{
					throw new Exception("获取图书馆室信息失败");
				}
			}
			catch (Exception ex)
			{
				Debug.Log(ex.Message);
				return int.MinValue;
			}
		}
		private int GetSeatId(string token, int roomId, string seatName)
		{
			try
			{
				DateTime dateTime = DateTime.Now.AddDays(1);
				string url = $"https://seat.ujn.edu.cn:8443/rest/v2/room/layoutByDate/{roomId}/{dateTime.Year:D4}-{dateTime.Month:D2}-{dateTime.Day:D2}?token={token}";
				Task<HttpResponseMessage> response = httpClient.GetAsync(url);
				response.Result.EnsureSuccessStatusCode();
				Task<byte[]> cont = response.Result.Content.ReadAsByteArrayAsync();
				SeatResponse roomResponse = JsonConvert.DeserializeObject<SeatResponse>(Encoding.UTF8.GetString(cont.Result));
				if (roomResponse.data.Equals("success"))
				{
					var list = roomResponse.data.layout;
					foreach (var item in list)
					{
						if (seatName.Equals(item.Value.name))
						{
							return item.Value.id;
						}
					}
					throw new Exception(seatName + "不存在");
				}
				else
				{
					throw new Exception("获取座位信息失败");
				}
			}
			catch (Exception ex)
			{
				Debug.Log(ex.Message);
				return int.MinValue;
			}
		}

		private bool Reserve(string token, int seatId, string beginTime, string endTime)
		{
			try
			{
				DateTime dateTime = DateTime.Now.AddDays(1);
				string url = "https://seat.ujn.edu.cn:8443/rest/v2/freeBook";
				HttpRequestMessage request = new HttpRequestMessage();
				request.Method = HttpMethod.Post;
				request.RequestUri = new Uri(url);
				request.Content = new StringContent($"token={token}&seat={seatId}&startTime={beginTime}&endTime={endTime}&date={dateTime.Year:D2}-{dateTime.Month:D2}-{dateTime.Day:D2}");
				request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
				Task<HttpResponseMessage> response = httpClient.SendAsync(request);
				response.Result.EnsureSuccessStatusCode();
				Task<byte[]> cont = response.Result.Content.ReadAsByteArrayAsync();
				ReservationResponse reservationResponse = JsonConvert.DeserializeObject<ReservationResponse>(Encoding.UTF8.GetString(cont.Result)); 
				if (reservationResponse.status == "success")
				{
					return true;
				}
				else
				{
					throw new Exception("预约失败");
				}
			}
			catch (Exception ex)
			{
				Debug.Log(ex.Message);
				return false;
			}	
		}
	}


}
