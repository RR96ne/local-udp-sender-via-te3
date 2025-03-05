# local-udp-sender-via-te3
localhostに対し文字列をUDP送信するプログラム  
ForgeのMod：[SummonByUdp](https://github.com/RR96ne/summon-by-udp-forge)用に作りました。  
TanuEsa3での使用を想定しています。  

## 使い方
### ダウンロード
[LocalUdpSenderViaTE3.zip](https://github.com/RR96ne/local-udp-sender-via-te3/releases/download/v1.0.0/LocalUdpSenderViaTE3.zip)をダウンロードし、任意の場所に解凍します。  
中に`LocalUdpSenderViaTE3.exe`が入っています。
### TanuEsa3で使用する場合
1. TanuEsa3のイベント設定→オペレーション一覧のでオペレーションを追加し、下の画面のタブのファイル実行を選びます。
1. ファイル選択で`LocalUdpSenderViaTE3.exe`を選択します。
1. 引数の編集で送信する文字を入れてください。
1. ポートを指定する場合は追加で`-p<ポート番号>`の引数も追加してください。(指定しなかった場合は5565が使用されます)
1. Twitchのチャネポ交換など、指定したイベントのトリガが引かれると、localhostに対してUDP送信されるはずです。
