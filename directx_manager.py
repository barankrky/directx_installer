import os, requests, zipfile, subprocess

def download_directx_zip(url, save_path):
    response = requests.get(url) 
    with open(save_path, 'wb') as file:
        file.write(response.content)

def extract_zip(zip_path, extract_to):
    with zipfile.ZipFile(zip_path, 'r') as zip_ref:
        zip_ref.extractall(extract_to)

def install_directx(installer_path):
    subprocess.run([installer_path, '/silent'], check=True)

def start():
    directx_url = 'https://example.com/directx.zip'  
    zip_path = 'directx.zip'
    extract_path = os.path.join(os.environ['TEMP'], 'directx_installer')
    installer_path = os.path.join(extract_path, 'directx_installer.exe')  

    print("DirectX zip dosyası indiriliyor...")
    download_directx_zip(directx_url, zip_path)

    print("Zip dosyası çıkarılıyor...")
    os.makedirs(extract_path, exist_ok=True)
    extract_zip(zip_path, extract_path)

    print("DirectX kurulumu başlatılıyor...")
    install_directx(installer_path)

    os.remove(zip_path)
    print("Kurulum tamamlandı ve geçici dosya silindi.")
