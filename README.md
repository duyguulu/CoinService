- Proje back-end ve front-end olmak üzere 2 bölümden oluşmaktadır. Front-end için(https://github.com/duyguulu/CoinDashBoard)
- Daha önceden sistemde tanımlı olan kullanıcılar, doğru kullanıcı adı ve şifre bilgisi ile back-end servisinden bir token alırlar, 
  kullanıcı adı ve şifre doğruysa Login ekranından yeni bir sayfaya yönlendirilir. Bu sayfa diğer hazırlanan back-end servisine bir istekte bulunur. 
- Bu servis coin’lerin api’den dönen fiyat, 24 saatlik değişim vb. alanlarını dönen bir servistir. Servisin sonucu kullanıcıya ekran üzerinde gösterilir.

- Projede EF Core paketi kullanıldı ve Code First yaklaşımı ile proje hazırlandı.
- Projede veritabanı için yerine Sqlite kullanıldı.
- Token olmadan yapılan isteklere cevap vermemektedir.
- Hatalı login işlemleri, CoinMarketCap api’ si çağrılırken alınan hatalar vb. durumlar bir dosyaya log olarak kaydedilmektedir.

- API servisi: https://coinmarketcap.com/api/documentation/v1/#section/Introduction
