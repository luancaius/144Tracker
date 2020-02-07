sudo apt-get update
sudo apt-get upgrade -y


wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

sudo add-apt-repository universe
sudo apt-get update
sudo apt-get install apt-transport-https -y
sudo apt-get update
sudo apt-get install dotnet-sdk-3.1 -y

git clone https://github.com/luancaius/144Tracker.git

