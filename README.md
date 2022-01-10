# MicroservicesDemo

**Kullanılan Teknolojiler**

1-) Mvc Core Web Api

2-) Background Service

3-) Rabbit MQ

4-) Postgre Sql

5-) Entity Framework Core

6-) Fluent Validation

7-) Automapper

8-) EPPlus nuget package (Excel dosyası üretmek için)


**Endpoint Bilgileri**

Api gateway dışarısı ile http:30000 portundan yayın yapmaktadır.

Contact mikroservisi http:60000 portundan yayın yapmaktadır.

Report mikroservisi http:50000 portundan yayın yapmaktadır.


**Rapor Talep İşlemi**

Herhangi bir konuma bağlı iletiş bilgileri raporlanmak istediğinde Api Gateway'in http://localhost:30000/talep/rapor/get-by-konum/{il_adı} adresinden talep başlatılır.

Talep alındığında Api Gateway tarafından Report servisine http://localhost:50000/api/rapor/get-by-konum/{il_adı} adresi üzerinden yönlendirilir. Burada Rapor tablosuna Rapor tablosuna istek durumu HAZIRLANIYOR olan bir kayıt eklenir.

Burada yer alan BackgroundService yardımıyla rapora verilen Id ve Konum bilgileri kuyruğa eklenir. (ReportRequestSender)

BackgroundService tarafından kuyruk izlenmektedir. (ReportRequestReceiver)

Kuyruktaki talep alındığında CreateReportCommand Contact servisine rapor bilgilerini çekmek üzere bir istek gönderilir. Bu istek http://localhost:60000/api/rapor/get/by-konum/{il_adi} adresine excel dosyasına kaydedilecek bilgileri alan bir istektir.

Bilgiler geldiğinde Excel dosyasına yazılır. Rapor tablosundaki kayıt güncellenir.







**Mimari**


![Screenshot](http://www.ibrahimarac.com/gitfiles/mimari.png)




**Proje Yapısı**


![Screenshot](http://www.ibrahimarac.com/gitfiles/katmanlar.png)


Rapor istek döngüsü

![Screenshot](http://www.ibrahimarac.com/gitfiles/service_lifetime.png)
