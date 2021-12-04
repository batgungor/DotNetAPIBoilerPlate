# .Net projeler için "Boiler Plate"

.Net Core ve 5+ Tabanlı pek çok proje için kullanılabilecek bir "boiler plate" yapısı. Katmanlı mimari ve Code-first yaklaşımı ile proje geliştirirken hem yol gösterici olması hemde hızlı bir başlangıç yapmak için temel pek çok özelliği içeriyor

## Katmanlar

### Application
Controllerlar ve DI management için kullanılan bu katmanda temel FE operasyonları için request handling işlemleri yapılıyor.

### Business
Projemizdeki iş akışları bu katmanda işleniyor. Operasyonel Engine mekanizmaları ve DTO'lar bu katmanda bulunmakta.

### Data
Veri tabanı erişimi ve yönetimi bu katmanda yapılıyor. 2 Projeden oluşan katman temelde Entity Management ve Data Access Layer fonksiyonalitesi taşıyor. Bu katmanda EntityFramework DBContext kurgusu, Generic Reposiyory mantığı ve UnitOfWork Yaklaşımı kullanılmıştır.
