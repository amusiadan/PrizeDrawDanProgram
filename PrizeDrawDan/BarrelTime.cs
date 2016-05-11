using System;

namespace PrizeDrawDan
{
	public class BarrelTime
	{
		int timeHour = 0;
		int timeMinute = 0;
		int timeTotalSeconds = 0; //represents the barrel time as seconds after midnight

		internal int hour
		{
			get
			{
				return timeHour;
			}
			set
			{
				timeHour = value;
				if (timeHour > 24) timeHour = 24;
				if (timeHour < 0) timeHour = 0;
				calculateSeconds();
			}
		}

		internal int minute
		{
			get
			{
				return timeMinute;
			}
			set
			{
				timeMinute = value;
				if (timeMinute > 59) timeMinute = 59;
				if (timeMinute < 0) timeMinute = 0;
				calculateSeconds();
			}
		}

		internal BarrelTime(int Hour, int minute)
		{
			timeHour = Hour;
			timeMinute = minute;
			if (timeHour > 24) timeHour = 24;
			if (timeHour < 0) timeHour = 0;
			if (timeMinute > 59) timeMinute = 59;
			if (timeMinute < 0) timeMinute = 0;
			calculateSeconds();
		}

		void calculateSeconds()
		{
			timeTotalSeconds = timeHour*3600+timeMinute*60;
			if (timeHour == 24) timeTotalSeconds -= 1;
		}


		///Seconds remaining to the barrel time
		internal int timeRemaining(DateTime time)
		{
			//Convert time to seconds
			int timeNowSeconds = time.Hour * 3600 + time.Minute * 60 + time.Second;
			return timeTotalSeconds - timeNowSeconds;
		}
}
}

