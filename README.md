# ImageResizer

Redimensionador simples de imagens, focado em otimizar o tamanho de arquivo mantendo a qualidade perceptível.

---

## ⚠️ Requisitos

Para executar este projeto, é necessário ter o **.NET 8.0 ou superior** instalado em sua máquina.

---

## 🚀 Como funciona

Após baixar os arquivos do projeto, navegue até o diretório: **".../ImageResizer/bin/Debug/net8.0"** e execute o arquivo **ImageResizer.exe**.

1. Ao iniciar, o app solicitará uma **altura personalizada** (em pixels). Após inserir a altura, o programa criará automaticamente as seguintes pastas de trabalho:

   - `Input_Files/` — onde você deve colocar as imagens que deseja redimensionar  
   - `Resized_Files/` — onde serão salvas as imagens redimensionadas:
     - Subpastas: `200_Pixels/`, `500_Pixels/`, `800_Pixels/` e `X_Pixels/` (sendo **X** a altura definida pelo usuário)
   - `Finished_Files/` — onde as imagens originais serão movidas após o processamento

2. O programa monitora constantemente a pasta `Input_Files/`. Quando uma imagem é detectada, são geradas versões redimensionadas com as seguintes alturas:

   - **200 px**, **500 px**, **800 px** e **a altura personalizada informada pelo usuário**

3. Caso um arquivo tenha formato não suportado, o programa exibirá uma **mensagem de erro**, e o arquivo será **excluído e ignorado**.

   **Formatos suportados:** `.jpg`, `.jpeg`, `.png`, `.jfif`

---

## 📁 Local das pastas

As pastas de trabalho são sempre criadas no diretório: **".../ImageResizer/bin/Debug/net8.0"**.

---

## ✅ Exemplo de fluxo de uso

1. Inicie o app e defina uma altura (ex: 600).
2. Coloque imagens em `Input_Files/`.
3. Aguarde o redimensionamento automático.
4. Imagens originais serão movidas para `Finished_Files/` e versões redimensionadas salvas em `Resized_Files/`.

---

## 🛠️ Sobre

Este projeto foi desenvolvido com foco em simplicidade e eficiência. Foi criado como um exercício pessoal para aprofundar meus conhecimentos em C# e treinar minha lógica de programação, aproveitando para praticar o desenvolvimento de uma ferramenta prática e funcional.

