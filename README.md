Erlang download: (msi) => [https://erlang.org/download/otp_versions_tree.html](https://erlang.org/download/otp_versions_tree.html)

Chocolaty download: (pwshell) => [https://chocolatey.org/install#install-step2](https://chocolatey.org/install#install-step2)

```Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))```

Web-Manager => [http://localhost:15672](http://localhost:15672)

Add CLI-Tools to your User PATH environement variable => ```C:\Program File\RabbitMQ Server\rabbitmq_server-3.10.6\sbin```

Enable Shoveling plugin (pwshell) => ```rabbitmq-plugins enable rabbitmq_shovel rabbitmq_shovel_management```

Enable Top plugin (pwshell) => ```rabbitmq-plugins enable rabbitmq_top```

**Used Architecture**
Routing with topic Exchange
![image](https://user-images.githubusercontent.com/68454661/180667155-528c8a2c-e9c9-49e5-a856-08edcf02ec46.png)


**OTHER ARCHITECTURES**

Basic request response patern
![image](https://user-images.githubusercontent.com/68454661/180667088-f57ec6c4-9b42-4fed-9562-a552b757cca5.png)

Fanout Exchange
![image](https://user-images.githubusercontent.com/68454661/180667207-db5a208b-1366-458b-b66e-3927056831be.png)

Routing with direct Exchange
![image](https://user-images.githubusercontent.com/68454661/180667134-da9d5243-9947-44a7-9403-0db7d96014bf.png)

Exchange to exchange
![image](https://user-images.githubusercontent.com/68454661/180666898-8ad350e5-6727-4df1-a9cf-c933e682b664.png)

Headers exchange
![image](https://user-images.githubusercontent.com/68454661/180666934-0d32ebfa-e4a0-4bff-b02f-e20a57222442.png)

Conssistent Hashing Exchange (plugin needed)
![image](https://user-images.githubusercontent.com/68454661/180667041-f1cb9c22-b639-4780-aed5-6e2526a538d8.png)

Dead letter managing architecture (fanout,alternate)
![image](https://user-images.githubusercontent.com/68454661/180666825-240f65e7-387f-41c7-ba9e-bb1aec7e52ef.png)
![image](https://user-images.githubusercontent.com/68454661/180666858-5e5393c1-565e-4627-a8d0-eb45730ab1bb.png)
