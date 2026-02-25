using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuditelWebServer.Server.Views
{
	public static class Home
	{
		public const string Html = @"<!doctype html>
<html lang=""bg"">
<head>
  <meta charset=""utf-8"" />
  <meta name=""viewport"" content=""width=device-width,initial-scale=1"" />
  <title>UrbanWear — Магазин за дрехи</title>
  <style>
    :root{
      --bg:#0b0c10;
      --panel:#12141a;
      --text:#e9eef7;
      --muted:#aab3c2;
      --brand:#6ee7ff;
      --brand2:#a78bfa;
      --border:rgba(255,255,255,.08);
      --shadow: 0 18px 60px rgba(0,0,0,.45);
      --radius:16px;
    }

    *{ box-sizing:border-box; }
    body{
      margin:0;
      font-family: ui-sans-serif, system-ui, -apple-system, Segoe UI, Roboto, Arial, ""Noto Sans"", ""Helvetica Neue"", sans-serif;
      color:var(--text);
      background:
        radial-gradient(900px 450px at 15% 10%, rgba(110,231,255,.18), transparent 55%),
        radial-gradient(700px 350px at 85% 15%, rgba(167,139,250,.18), transparent 55%),
        linear-gradient(180deg, #07080b, var(--bg));
      line-height:1.5;
    }

    a{ color:inherit; text-decoration:none; }
    .container{ width:min(1100px, 92%); margin:0 auto; }

    /* Header */
    header{
      position:sticky;
      top:0;
      z-index:10;
      backdrop-filter: blur(10px);
      background: rgba(11,12,16,.72);
      border-bottom:1px solid var(--border);
    }
    .nav{
      display:flex;
      align-items:center;
      justify-content:space-between;
      gap:16px;
      padding:14px 0;
    }
    .brand{
      display:flex;
      align-items:center;
      gap:10px;
      font-weight:800;
      letter-spacing:.2px;
    }
    .logo{
      width:34px; height:34px;
      border-radius:12px;
      background: linear-gradient(135deg, var(--brand), var(--brand2));
      box-shadow: 0 10px 30px rgba(110,231,255,.12);
    }
    nav ul{
      list-style:none;
      display:flex;
      gap:14px;
      padding:0;
      margin:0;
      flex-wrap:wrap;
      justify-content:flex-end;
    }
    nav a{
      padding:8px 10px;
      border-radius:10px;
      color:var(--muted);
      border:1px solid transparent;
    }
    nav a:hover{
      color:var(--text);
      border-color:var(--border);
      background: rgba(255,255,255,.04);
    }

    .nav-actions{
      display:flex;
      gap:10px;
      align-items:center;
    }
    .search{
      display:flex;
      align-items:center;
      gap:8px;
      padding:8px 10px;
      border:1px solid var(--border);
      border-radius:12px;
      background: rgba(255,255,255,.04);
      min-width: 210px;
    }
    .search input{
      width:100%;
      border:none;
      outline:none;
      background:transparent;
      color:var(--text);
      font-size:14px;
    }
    .pill{
      padding:8px 10px;
      border:1px solid var(--border);
      border-radius:999px;
      background: rgba(255,255,255,.04);
      color:var(--muted);
      font-size:14px;
      white-space:nowrap;
    }

    /* Hero */
    .hero{
      padding:42px 0 18px;
    }
    .hero-grid{
      display:grid;
      grid-template-columns: 1.25fr .75fr;
      gap:18px;
      align-items:stretch;
    }
    .card{
      background: rgba(18,20,26,.78);
      border:1px solid var(--border);
      border-radius: var(--radius);
      box-shadow: var(--shadow);
    }
    .hero-main{
      padding:26px;
      overflow:hidden;
      position:relative;
    }
    .badge{
      display:inline-flex;
      align-items:center;
      gap:8px;
      padding:8px 12px;
      border-radius:999px;
      border:1px solid var(--border);
      background: rgba(255,255,255,.04);
      color:var(--muted);
      font-size:13px;
    }
    .badge b{ color:var(--text); }
    h1{
      margin:14px 0 8px;
      font-size: clamp(28px, 3.6vw, 44px);
      line-height:1.12;
      letter-spacing:-.6px;
    }
    .lead{
      margin:0 0 18px;
      color:var(--muted);
      max-width: 60ch;
    }
    .cta-row{
      display:flex;
      gap:10px;
      flex-wrap:wrap;
      margin-top: 10px;
    }
    .btn{
      display:inline-flex;
      align-items:center;
      justify-content:center;
      padding:10px 14px;
      border-radius:12px;
      border:1px solid var(--border);
      background: rgba(255,255,255,.04);
      color:var(--text);
      font-weight:600;
    }
    .btn:hover{ background: rgba(255,255,255,.08); }
    .btn.primary{
      border-color: transparent;
      background: linear-gradient(135deg, rgba(110,231,255,.22), rgba(167,139,250,.22));
    }

    .hero-side{
      padding:18px;
      display:grid;
      gap:12px;
    }
    .stat{
      padding:14px;
      border-radius:14px;
      border:1px solid var(--border);
      background: rgba(255,255,255,.03);
    }
    .stat .k{
      font-size:22px;
      font-weight:800;
      letter-spacing:-.4px;
    }
    .stat .t{
      color:var(--muted);
      font-size:13px;
      margin-top:4px;
    }

    /* Sections */
    main{ padding: 14px 0 60px; }
    .section{
      margin-top: 18px;
    }
    .section-header{
      display:flex;
      align-items:flex-end;
      justify-content:space-between;
      gap:12px;
      margin-bottom: 12px;
    }
    .section h2{
      margin:0;
      font-size:20px;
      letter-spacing:-.2px;
    }
    .section p{
      margin:0;
      color:var(--muted);
      font-size:14px;
    }

    /* Category chips */
    .chips{
      display:flex;
      gap:10px;
      flex-wrap:wrap;
      margin: 10px 0 0;
    }
    .chip{
      padding:8px 12px;
      border-radius:999px;
      border:1px solid var(--border);
      background: rgba(255,255,255,.04);
      color:var(--muted);
      font-size:14px;
    }
    .chip:hover{ color:var(--text); background: rgba(255,255,255,.07); }

    /* Product grid (text-only cards) */
    .grid{
      display:grid;
      grid-template-columns: repeat(4, 1fr);
      gap:12px;
    }
    .product{
      padding:14px;
      border-radius:16px;
      border:1px solid var(--border);
      background: rgba(255,255,255,.03);
      display:grid;
      gap:8px;
      min-height: 152px;
    }
    .product .top{
      display:flex;
      align-items:center;
      justify-content:space-between;
      gap:10px;
    }
    .tag{
      font-size:12px;
      color:var(--muted);
      padding:6px 10px;
      border-radius:999px;
      border:1px solid var(--border);
      background: rgba(255,255,255,.03);
    }
    .product h3{
      margin:0;
      font-size:16px;
      letter-spacing:-.2px;
    }
    .meta{
      display:flex;
      gap:10px;
      flex-wrap:wrap;
      color:var(--muted);
      font-size:13px;
    }
    .price{
      font-weight:800;
      letter-spacing:-.2px;
    }
    .product .actions{
      display:flex;
      gap:10px;
      margin-top: 6px;
    }
    .btn.small{
      padding:8px 10px;
      border-radius:12px;
      font-size:13px;
      color:var(--muted);
    }
    .btn.small:hover{ color:var(--text); }

    /* Promo strip */
    .promo{
      padding:16px;
      display:flex;
      align-items:center;
      justify-content:space-between;
      gap:14px;
    }
    .promo strong{ font-size:16px; }
    .promo span{ color:var(--muted); font-size:14px; }

    /* Footer */
    footer{
      border-top:1px solid var(--border);
      background: rgba(11,12,16,.65);
      padding:24px 0;
      color:var(--muted);
      font-size:14px;
    }
    .footer-grid{
      display:grid;
      grid-template-columns: 1.2fr .8fr;
      gap:14px;
      align-items:start;
    }
    .footer-links{
      display:flex;
      gap:14px;
      flex-wrap:wrap;
    }
    .footer-links a{
      padding:6px 10px;
      border-radius:10px;
      border:1px solid transparent;
      color:var(--muted);
    }
    .footer-links a:hover{
      color:var(--text);
      border-color:var(--border);
      background: rgba(255,255,255,.04);
    }

    /* Responsive */
    @media (max-width: 900px){
      .hero-grid{ grid-template-columns: 1fr; }
      .search{ min-width: 150px; }
      .grid{ grid-template-columns: repeat(2, 1fr); }
      .footer-grid{ grid-template-columns: 1fr; }
    }
    @media (max-width: 520px){
      nav ul{ display:none; }
      .grid{ grid-template-columns: 1fr; }
      .search{ display:none; }
    }
  </style>
</head>

<body>
  <header>
    <div class=""container"">
      <div class=""nav"">
        <a class=""brand"" href=""#"">
          <span class=""logo"" aria-hidden=""true""></span>
          <span>UrbanWear</span>
        </a>

        <nav aria-label=""Основна навигация"">
          <ul>
            <li><a href=""#new"">Ново</a></li>
            <li><a href=""#men"">Мъже</a></li>
            <li><a href=""#women"">Жени</a></li>
            <li><a href=""#sale"">Разпродажба</a></li>
            <li><a href=""#contact"">Контакти</a></li>
          </ul>
        </nav>

        <div class=""nav-actions"">
          <div class=""search"" role=""search"">
            <span aria-hidden=""true"">⌕</span>
            <input type=""search"" placeholder=""Търси: тениска, дънки, яке…"" />
          </div>
          <a class=""pill"" href=""#cart"" aria-label=""Количка"">Количка (0)</a>
        </div>
      </div>
    </div>
  </header>

  <section class=""hero"">
    <div class=""container"">
      <div class=""hero-grid"">
        <div class=""card hero-main"">
          <div class=""badge"">
            <span aria-hidden=""true"">★</span>
            <span><b>Нова колекция</b> · минималистичен стил · бърза доставка</span>
          </div>

          <h1>Дрехи, които изглеждат добре — без излишен шум.</h1>
          <p class=""lead"">
            Изчистени линии, удобни материи и модели, които стават и за училище/офис, и за уикенд.
            Разгледай новите предложения и сглоби визия за 2 минути.
          </p>

          <div class=""cta-row"">
            <a class=""btn primary"" href=""#new"">Разгледай новото</a>
            <a class=""btn"" href=""#sale"">Виж разпродажбата</a>
            <a class=""btn"" href=""#contact"">Абонамент за новини</a>
          </div>

          <div class=""chips"" aria-label=""Категории"">
            <a class=""chip"" href=""#new"">Тениски</a>
            <a class=""chip"" href=""#new"">Суичъри</a>
            <a class=""chip"" href=""#new"">Дънки</a>
            <a class=""chip"" href=""#new"">Якета</a>
            <a class=""chip"" href=""#new"">Аксесоари</a>
          </div>
        </div>

        <aside class=""card hero-side"" aria-label=""Ключови предимства"">
          <div class=""stat"">
            <div class=""k"">24–48 ч</div>
            <div class=""t"">доставка в България</div>
          </div>
          <div class=""stat"">
            <div class=""k"">30 дни</div>
            <div class=""t"">право на връщане</div>
          </div>
          <div class=""stat"">
            <div class=""k"">S–XXL</div>
            <div class=""t"">размери за всеки</div>
          </div>
          <div class=""stat"">
            <div class=""k"">−20%</div>
            <div class=""t"">код: <b style=""color:var(--text)"">URBAN20</b></div>
          </div>
        </aside>
      </div>
    </div>
  </section>

  <main class=""container"">
    <section id=""new"" class=""section"">
      <div class=""section-header"">
        <div>
          <h2>Нови предложения</h2>
          <p>Текстови карти вместо снимки — идеално за демо/учебен проект.</p>
        </div>
        <a class=""btn small"" href=""#new"" title=""Примерен линк"">Виж всички →</a>
      </div>

      <div class=""grid"" aria-label=""Продукти - Ново"">
        <article class=""product"">
          <div class=""top"">
            <span class=""tag"">Ново</span>
            <span class=""price"">39.90 лв</span>
          </div>
          <h3>Basic Tee “Graphite”</h3>
          <div class=""meta"">
            <span>Материя: памук</span>
            <span>Кройка: regular</span>
            <span>Размери: S–XL</span>
          </div>
          <div class=""actions"">
            <a class=""btn small"" href=""#"">Детайли</a>
            <a class=""btn small primary"" href=""#"">Добави</a>
          </div>
        </article>

        <article class=""product"">
          <div class=""top"">
            <span class=""tag"">Топ</span>
            <span class=""price"">89.90 лв</span>
          </div>
          <h3>Hoodie “Soft Lilac”</h3>
          <div class=""meta"">
            <span>Материя: памук/полиестер</span>
            <span>Кройка: relaxed</span>
            <span>Размери: S–XXL</span>
          </div>
          <div class=""actions"">
            <a class=""btn small"" href=""#"">Детайли</a>
            <a class=""btn small primary"" href=""#"">Добави</a>
          </div>
        </article>

        <article class=""product"">
          <div class=""top"">
            <span class=""tag"">Лимитирано</span>
            <span class=""price"">129.00 лв</span>
          </div>
          <h3>Denim “Midnight”</h3>
          <div class=""meta"">
            <span>Материя: деним</span>
            <span>Кройка: slim</span>
            <span>Размери: 28–36</span>
          </div>
          <div class=""actions"">
            <a class=""btn small"" href=""#"">Детайли</a>
            <a class=""btn small primary"" href=""#"">Добави</a>
          </div>
        </article>

        <article class=""product"">
          <div class=""top"">
            <span class=""tag"">Еко</span>
            <span class=""price"">159.00 лв</span>
          </div>
          <h3>Light Jacket “Breeze”</h3>
          <div class=""meta"">
            <span>Материя: рециклиран текстил</span>
            <span>Кройка: regular</span>
            <span>Размери: S–XL</span>
          </div>
          <div class=""actions"">
            <a class=""btn small"" href=""#"">Детайли</a>
            <a class=""btn small primary"" href=""#"">Добави</a>
          </div>
        </article>
      </div>
    </section>

    <section class=""section"">
      <div class=""card promo"">
        <div>
          <strong>Без снимки, но с характер.</strong><br />
          <span>Използвай този шаблон за упражнение: layout, cards, responsive и hover ефекти.</span>
        </div>
        <a class=""btn primary"" href=""#contact"">Запиши се</a>
      </div>
    </section>

    <section id=""sale"" class=""section"">
      <div class=""section-header"">
        <div>
          <h2>Разпродажба</h2>
          <p>Няколко примерни артикула с отстъпка.</p>
        </div>
        <a class=""btn small"" href=""#sale"">Филтри →</a>
      </div>

      <div class=""grid"" aria-label=""Продукти - Разпродажба"">
        <article class=""product"">
          <div class=""top"">
            <span class=""tag"">−30%</span>
            <span class=""price"">27.90 лв</span>
          </div>
          <h3>Cap “No-Logo”</h3>
          <div class=""meta"">
            <span>Цвят: черен</span>
            <span>Размер: adjustable</span>
          </div>
          <div class=""actions"">
            <a class=""btn small"" href=""#"">Детайли</a>
            <a class=""btn small primary"" href=""#"">Добави</a>
          </div>
        </article>

        <article class=""product"">
          <div class=""top"">
            <span class=""tag"">−25%</span>
            <span class=""price"">59.90 лв</span>
          </div>
          <h3>Shirt “Clean White”</h3>
          <div class=""meta"">
            <span>Материя: памук</span>
            <span>Кройка: regular</span>
            <span>Размери: S–XL</span>
          </div>
          <div class=""actions"">
            <a class=""btn small"" href=""#"">Детайли</a>
            <a class=""btn small primary"" href=""#"">Добави</a>
          </div>
        </article>

        <article class=""product"">
          <div class=""top"">
            <span class=""tag"">−40%</span>
            <span class=""price"">71.40 лв</span>
          </div>
          <h3>Pants “Everyday”</h3>
          <div class=""meta"">
            <span>Материя: cotton blend</span>
            <span>Кройка: tapered</span>
            <span>Размери: S–XXL</span>
          </div>
          <div class=""actions"">
            <a class=""btn small"" href=""#"">Детайли</a>
            <a class=""btn small primary"" href=""#"">Добави</a>
          </div>
        </article>

        <article class=""product"">
          <div class=""top"">
            <span class=""tag"">−15%</span>
            <span class=""price"">118.15 лв</span>
          </div>
          <h3>Overshirt “Stone”</h3>
          <div class=""meta"">
            <span>Материя: плътен памук</span>
            <span>Кройка: boxy</span>
            <span>Размери: S–XL</span>
          </div>
          <div class=""actions"">
            <a class=""btn small"" href=""#"">Детайли</a>
            <a class=""btn small primary"" href=""#"">Добави</a>
          </div>
        </article>
      </div>
    </section>

    <section id=""contact"" class=""section"">
      <div class=""section-header"">
        <div>
          <h2>Контакт и бюлетин</h2>
          <p>Форма (само HTML) — без бекенд. Подходящо за упражнение по валидиране.</p>
        </div>
      </div>

      <div class=""card"" style=""padding:18px;"">
        <form>
          <div style=""display:grid; grid-template-columns: 1fr 1fr; gap:12px;"">
            <label>
              <div style=""color:var(--muted); font-size:13px; margin-bottom:6px;"">Име</div>
              <input required name=""name"" placeholder=""Иван Иванов""
                style=""width:100%; padding:10px 12px; border-radius:12px; border:1px solid var(--border); background:rgba(255,255,255,.03); color:var(--text); outline:none;"" />
            </label>

            <label>
              <div style=""color:var(--muted); font-size:13px; margin-bottom:6px;"">Имейл</div>
              <input required type=""email"" name=""email"" placeholder=""you@example.com""
                style=""width:100%; padding:10px 12px; border-radius:12px; border:1px solid var(--border); background:rgba(255,255,255,.03); color:var(--text); outline:none;"" />
            </label>
          </div>

          <label style=""display:block; margin-top:12px;"">
            <div style=""color:var(--muted); font-size:13px; margin-bottom:6px;"">Съобщение</div>
            <textarea name=""message"" rows=""4"" placeholder=""Въпрос за доставка, размери или наличност…""
              style=""width:100%; padding:10px 12px; border-radius:12px; border:1px solid var(--border); background:rgba(255,255,255,.03); color:var(--text); outline:none; resize:vertical;""></textarea>
          </label>

          <div style=""display:flex; gap:10px; flex-wrap:wrap; margin-top:12px; align-items:center;"">
            <button class=""btn primary"" type=""submit"">Изпрати</button>
            <button class=""btn"" type=""reset"">Изчисти</button>
            <span style=""color:var(--muted); font-size:13px;"">* Демонстрационна форма</span>
          </div>
        </form>
      </div>
    </section>
  </main>

  <footer>
    <div class=""container"">
      <div class=""footer-grid"">
        <div>
          <div style=""display:flex; align-items:center; gap:10px; margin-bottom:8px;"">
            <span class=""logo"" aria-hidden=""true""></span>
            <strong style=""color:var(--text)"">UrbanWear</strong>
          </div>
          <div>© <span id=""y""></span> UrbanWear. Всички права запазени.</div>
          <div style=""margin-top:6px;"">Демо home страница за магазин (без изображения).</div>
        </div>

        <div>
          <div class=""footer-links"" aria-label=""Линкове"">
            <a href=""#new"">Ново</a>
            <a href=""#sale"">Разпродажба</a>
            <a href=""#contact"">Контакти</a>
            <a href=""#"">Условия</a>
            <a href=""#"">Поверителност</a>
          </div>
        </div>
      </div>
    </div>
  </footer>

  <script>
    document.getElementById(""y"").textContent = new Date().getFullYear();
  </script>
</body>
</html>
";
	}
}
