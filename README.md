# FindFileInZip

Find file in all zip files. 

### Command Usage

FindFileInZip.exe **find** [OPTIONS]

- `dictionaryPath` : Target directory path that contains zip files. ex.) `C:\zip_files`
- `pathInZip` : Search path you want to find. ex.) `dist/css/bootstrap-theme.css`

```
FindFileInZip.exe find --dictionaryPath=C:\zip_files --pathInZip=dist/css/bootstrap-theme.css
```