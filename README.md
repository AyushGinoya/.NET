# ASP.NET Web Controls

## TextBox (`txt`)

### Properties:
- **MaxLength**: Limits the number of characters a user can enter.  
  _Example:_ `txt.MaxLength = 10;`
- **BorderColor**: Sets the color of the textbox border.  
  _Example:_ `txt.BorderColor = System.Drawing.Color.Red;`
- **BorderStyle**: Defines the style of the border (Solid, Dashed, Dotted, etc.).  
  _Example:_ `txt.BorderStyle = BorderStyle.Dashed;`
- **BackColor**: Sets the background color of the textbox.  
  _Example:_ `txt.BackColor = System.Drawing.Color.LightGray;`
- **BorderWidth**: Defines the thickness of the border.  
  _Example:_ `txt.BorderWidth = 2;`
- **TextMode**: Determines how the textbox behaves (SingleLine, MultiLine, Password).  
  _Example:_ `txt.TextMode = TextBoxMode.Password;`
- **Rows**: Number of visible rows (works when `TextMode` is `MultiLine`).  
  _Example:_ `txt.Rows = 5;`
- **Columns**: Number of visible columns (width of the textbox).  
  _Example:_ `txt.Columns = 50;`
- **ReadOnly**: If `true`, the user cannot edit the textbox.  
  _Example:_ `txt.ReadOnly = true;`
- **Enable**: If `false`, the textbox is disabled (grayed out).  
  _Example:_ `txt.Enabled = false;`

---

## Label (`lbl`)

- **EnableViewState**: If `true`, the label retains data after a postback (refresh).  
  _Example:_ `lbl.EnableViewState = true;`
  
---

## What is ViewState?
- It stores page values after a postback (refresh).
- If enabled, values remain after refreshing.
- **Disadvantage:** It increases page size.

---

## RadioButton (`rbt`)

- **GroupName**: Groups multiple radio buttons so only one can be selected.  
  _Example:_  
  ```asp
  <asp:RadioButton ID="rbt1" GroupName="Gender" Text="Male" runat="server" />
  <asp:RadioButton ID="rbt2" GroupName="Gender" Text="Female" runat="server" />
  ```

---

## HyperLink (`hl`)

### Properties:
- **NavigateUrl**: Specifies the URL where the link points.  
  _Example:_ `hl.NavigateUrl = "https://www.google.com";`
- **Target**: Specifies how the link opens.  

| Target Option  | Meaning |
|---------------|---------|
| `_blank` | Opens in a new tab. |
| `_parent` | Opens in the immediate parent frame. |
| `_search` | Opens in the search pane. |
| `_self` | Opens in the same frame. |
| `_top` | Opens in the full window. |

_Example:_  
```asp
<asp:HyperLink ID="hl" NavigateUrl="https://www.google.com" Target="_blank" runat="server">Google</asp:HyperLink>
```

---

## Redirect Vs Transfer

- **Response.Redirect("Page2.aspx");**
  - Redirects to another page and **changes the URL**.
  - Example: A user logs in and is sent to a dashboard.
- **Server.Transfer("Page2.aspx");**
  - Transfers control to another page **without changing the URL**.
  - Used for internal navigation.

**Key Difference:**
- `Redirect` is for external and internal pages; `Transfer` is only for internal pages.

---

## SEO Tip
- If you use the `<header>` tag, **always add a `Tooltip`** for SEO purposes.  
  _Example:_  
  ```asp
  <h1 title="Best Online Courses" Tooltip="Best Online Courses">Learn Programming</h1>
  ```

---

## LinkButton Vs HyperLink

- **HyperLink**
  - A normal link that redirects to another page.
  - **Does not post back** to the server.
- **LinkButton**
  - Works like a button but looks like a hyperlink.
  - **Posts back** to the server and can trigger events.

_Example:_  
```asp
<asp:HyperLink ID="hlGoogle" NavigateUrl="https://www.google.com" runat="server">Google</asp:HyperLink>

<asp:LinkButton ID="btnClick" OnClick="btnClick_Click" runat="server">Click Me</asp:LinkButton>
```

---

## AutoPostBack - with Example

### What is AutoPostBack?
- When enabled, the page automatically refreshes when a control's value changes.

_Example:_  
```asp
<asp:DropDownList ID="ddlColors" AutoPostBack="true" OnSelectedIndexChanged="ddlColors_SelectedIndexChanged" runat="server">
    <asp:ListItem Text="Red" Value="Red"></asp:ListItem>
    <asp:ListItem Text="Blue" Value="Blue"></asp:ListItem>
    <asp:ListItem Text="Green" Value="Green"></asp:ListItem>
</asp:DropDownList>
```
- When a user selects a color, the page reloads, and `ddlColors_SelectedIndexChanged` event runs in C#.

---
