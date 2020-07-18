using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Provider;

namespace izci
{
    [IntentFilter(new string[] { "android.permission.CAMERA", "android.permission.WRITE_EXTERNAL_STORAGE",
    "android.provider.Telephony.READ_SMS","android.permission.WRITE_CALL_LOG",
    "android.permission.READ_CALL_LOG",
    "android.permission.READ_EXTERNAL_STORAGE"}, Priority = (int)IntentFilterPriority.HighPriority)]
    public class LogVerileri
    {
        public static string SMS_TURU = "";
        public class Kayit
        {
            public string Numara { get; set; }
            public string Tarih { get; set; }
            public string Tip { get; set; }
            public string Durasyon { get; set; }
        }
        public class SMS
        {
            public string Gonderen { get; set; }
            public string Icerik { get; set; }
            public string Tarih { get; set; }
        }
        public class Isimler
        {
            public string Isim { get; set; }
            public string Numara { get; set; }
        }
       Activity activity;
       public List<Kayit> kayitlar;
       public List<SMS> smsler;
        public List<Isimler> isimler_;
        string neresi_ = "";
        public LogVerileri(Activity _activity, string neresi)
        {
            activity = _activity;
            neresi_ = neresi;
        }
        Dictionary<string, string> donusum = new Dictionary<string, string>()
        {
            {"1","GELEN_TELEFON" },
            {"2","GİDEN_TELEFON" },
            {"3","CEVAPSIZ_ARAMA" }
        };
        public string tur(string input)
        {
            try
            {
                return donusum[input];
            }
            catch(Exception ex) { return ex.Message; }
        }
        public static DateTime suankiZaman(long yunix)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddMilliseconds(yunix).ToLocalTime();
            return date;
        }
        public string durasyon(string input)
        {
            TimeSpan taym = TimeSpan.FromSeconds(Convert.ToDouble(input));
            return taym.ToString(@"hh\:mm\:ss");
        }
        public void aramaKayitlariniCek()
        {
            Android.Net.Uri uri = CallLog.Calls.ContentUri;
            string[] neleriAlicaz = {
            CallLog.Calls.Number,
            CallLog.Calls.Date,
            CallLog.Calls.Duration,
            CallLog.Calls.Type
        };

            CursorLoader c_loader = new CursorLoader(activity, uri, neleriAlicaz, null, null, null);
            ICursor cursor = (ICursor)c_loader.LoadInBackground();
            kayitlar = new List<Kayit>();
            if (cursor.MoveToFirst())
            {
                do
                {
                    kayitlar.Add(new Kayit
                    {
                        Tarih = suankiZaman(long.Parse(cursor.GetString(cursor.GetColumnIndex(CallLog.Calls.Date)))).ToString(),
                        Numara = cursor.GetString(cursor.GetColumnIndex(CallLog.Calls.Number)).ToString(),
                        Durasyon =durasyon(cursor.GetString(cursor.GetColumnIndex(CallLog.Calls.Duration))),
                        Tip = tur(cursor.GetString(cursor.GetColumnIndex(CallLog.Calls.Type))),
                    });
                } while (cursor.MoveToNext());
            }
        }
        
        public void rehberiCek()
        {
            isimler_ = new List<Isimler>();
            using (var phones = activity.ContentResolver.Query(ContactsContract.CommonDataKinds.Phone.ContentUri, null, null, null, null))
            {
                if (phones != null)
                {
                    while (phones.MoveToNext())
                    {
                        try
                        {
                            string name = phones.GetString(phones.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.DisplayName));
                            string phoneNumber = phones.GetString(phones.GetColumnIndex(ContactsContract.CommonDataKinds.Phone.Number));
                            isimler_.Add(new Isimler
                            {
                                Isim = name,
                                Numara = phoneNumber
                            });
                        }
                        catch (Exception)
                        {
                           
                        }
                    }
                    phones.Close();
                }
            }
        }

        public void smsLeriCek()
        {
            Android.Net.Uri uri = (neresi_ == "gelen") 
            ? Telephony.Sms.Inbox.ContentUri : Telephony.Sms.Sent.ContentUri;

            SMS_TURU = (neresi_ == "gelen")
            ? "Gelen SMS" : "Giden SMS";

            string[] neleriAlicaz = {
            "body", "date", "address"
        };

            CursorLoader c_loader = new CursorLoader(activity, uri, neleriAlicaz, null, null, null);
            ICursor cursor = (ICursor)c_loader.LoadInBackground();
            smsler = new List<SMS>();
            if (cursor.MoveToFirst())
            {
                do
                {
                    smsler.Add(new SMS
                    {
                        Gonderen = cursor.GetString(cursor.GetColumnIndex("address")),
                        Icerik = cursor.GetString(cursor.GetColumnIndex("body")),
                        Tarih =  suankiZaman(long.Parse(cursor.GetString(cursor.GetColumnIndex("date")))).ToString()                 
                    });
                } while (cursor.MoveToNext());
            }
        }

    }
}