# ImageResizer

Redimensionador simples de imagens, focado em otimizar tamanho de arquivo mantendo qualidade perceptível.

**IMPORTANTE**

Para executar esse projeto, você deve ter instalado na sua máquina o .NET 8.0 ou uma versão mais recente.

## Como funciona

Apos baixar os arquivos, va para o diretorio: ".../ImageResizer/bin/Debug/net8.0" e execute o arquivo ImageResizer.exe.

1. Ao iniciar, o app pede uma **altura** (em pixels) apos digitar a altura, o programa cria as pastas de trabalho:
   - `Input_Files/` — coloque aqui as imagens de entrada
   - `Resized_Files/` — saídas redimensionadas
     - `200_Pixels/`, `500_Pixels/`, `800_Pixels/` e `X_Pixels/` (X = altura escolhida)
   - `Finished_Files/` — o arquivo original é movido para cá após o processamento

2. O programa monitora `Input_Files/`. Ao encontrar uma imagem, gera as versões nas alturas:
   - **200 px**, **500 px**, **800 px** e **altura escolhida pelo usuário**.

3. Em caso de formato não suportado, uma **mensagem de erro** é exibida e o arquivo é deletado e ignorado.
   Os formatos permitidos sao: ".jpg", ".jpeg", ".png", ".jfif".

## Onde as pastas são criadas (importante)

As pastas são criadas no diretório: **".../ImageResizer/bin/Debug/net8.0"**.
