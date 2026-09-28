import pathlib

root = pathlib.Path(__file__).resolve().parent
nav = (root / "navigation.html").read_text(encoding="utf-8")
nav = nav.replace("\\", "\\\\").replace("`", "\\`").replace("${", "\\${")
loader_path = root / "scripts" / "navigation-loader.js"
loader = loader_path.read_text(encoding="utf-8")
old = 'navigationPageText = fetch(pathToRoot + "navigation.html").then(response => response.text())'
if old not in loader:
    raise SystemExit("fetch line not found")
loader_path.write_text(loader.replace(old, "navigationPageText = Promise.resolve(`" + nav + "`)"), encoding="utf-8")
print(loader_path.stat().st_size)
