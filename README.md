# DirectX Runtimes All-in-One Installer

Bu proje, DirectX runtime paketlerini otomatik olarak indirip kuran bir Python scripti içerir. Script, DirectX paketlerini GitHub'dan indirir, geçici bir klasöre çıkarır ve sessiz modda kurulumu gerçekleştirir.

## Özellikler

- DirectX runtime paketlerini otomatik indirme
- Paketleri geçici bir klasöre çıkarma
- Sessiz modda kurulum
- Kurulum sonrası geçici dosyaları temizleme

## İndir
- [Buraya tıklayarak](https://github.com/barankrky/directx_installer/releases/latest) kurulum dosyasını indirebilirsiniz.

## Kaynak Kodu

1. Projeyi klonlayın:
   ```bash
   git clone https://github.com/barankrky/directx_installer.git
   ```

2. Gerekli kütüphaneleri yükleyin:
   ```bash
   pip install requests
   ```

3. Scripti çalıştırın:
   ```bash
   python main.py
   ```

## Kullanım

Scripti çalıştırdığınızda otomatik olarak DirectX runtime paketlerini indirip kuracaktır. Kurulum tamamlandıktan sonra script otomatik olarak kapanacaktır.

## Katkıda Bulunma

Katkıda bulunmak isterseniz lütfen bir pull request gönderin. Önemli değişiklikler için önce bir issue açarak tartışalım.

## Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Daha fazla bilgi için [LICENSE](LICENSE) dosyasına bakın.