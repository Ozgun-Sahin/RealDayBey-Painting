![](ReadMeIMages/AnaSayfa.gif)
RealDayBey Painting, ASP.NET MVC 5 ile geliştirdiğim kişisel bir Portfolyo uygulamasıdır. 
<h2> 🛠 &nbsp;Kullanılan Teknolojiler ve Projenin Kurulumu</h2>

<table style"float:right;">
  <tr>
    <td><img src="https://img.shields.io/badge/-JavaScript-black?style=flat&logo=javascript"/></td>
    <td><img src="https://img.shields.io/badge/-HTML5-E34F26?style=flat&logo=html5&logoColor=white"></td>
    <td><img src="https://img.shields.io/badge/-CSS3-1572B6?style=flat&logo=css3"/></td>
    <td><img src="https://img.shields.io/badge/-EntityFramework-5C2D91?style=flat&logo=.net&logoColor=white"/></td>
    <td><img src="https://img.shields.io/badge/-ASP.NET-5C2D91?style=flat&logo=.net&logoColor=white"/></td>
    <td><img src="https://img.shields.io/badge/-Github-black?style=flat&logo=github"/></td>
    <td><img src="https://img.shields.io/badge/-Git-black?style=flat&logo=git"/></td>
    <td><img src="https://img.shields.io/badge/-Bootstrap-563D7C?style=flat&logo=bootstrap"/></td>
    <td><img src="https://img.shields.io/badge/-Sql%20Server-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=ffffff"/></td>
  </tr>
</table>

Porjeyi lokalde çalıştırmak için Microsoft Sql Server'ın bilgisayarınızda kurulu olması gerekmektedir.
Projeyi açtıktan sonra Package Manager Console üzerinden önce default proje olarak **DataAccessLayer**'i seçin sonra **update-database** komutunu giriniz.
Bu komut girildikten sonra SQL bağlantısı kurulacak ve bir **Admin** rolüne sahip kullanıcı oluşturulacaktır. 
(Tüm özellikler denenebilmesi için herhangi bir başka örnek veri yoktur. Bu sebeple ilk etapta Ana Sayfadaki değiştirilebilir alanlar boş gelecektir. Admin Panelinden bu kısımları düzenleyebilirsiniz.)
  
#### Admin Kullanıcı Adı: Admin
#### Admin Şifre: Admin060155013!

Proje, Ana sayfa, Admin paneli ve Müşteri paneli olmak üzere üç kısımda incelenebilir.

### 🧑‍🎨 Admin (Portfolyo Sahibi) Rolü
* Ana Sayfayı düzenleyebilir
* Müşterilerle iletişime geçebilir
* Gelen Projeleri onaylayabilir, düzenleyebilir
* Aylık gelir / gider kontrolü
* Duyurular yapabilir
* Müşteri görüşlerinin onayı ve kontrolü

## Admin Paneli
![](ReadMeIMages/AdminPaneli.jpg)

### 👥 Müşteri Rolü
* Admin (Portfolyo Sahibi) ile iletişime geçebilir
* Proje talep edebilir
* Onaylanan Projelerin süreçlerini takip edebilir

## Müşteri Paneli
![](ReadMeIMages/CustomerDashBoard.jpg)
