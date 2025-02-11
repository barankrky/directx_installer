import os
import directx_manager as dm

title = """--------------------------------------------------------------------------------
  DirectX Runtimes All-in-One Installer by barankrky 
  https://github.com/barankrky/directx_installer 
--------------------------------------------------------------------------------
"""

if __name__ == '__main__':
    os.system("title DirectX Runtimes All-in-One Installer by barankrky")
    os.system('cls')
    print(title)
    dm.start()