/*******************************************************************************
* JavaScript Hashtable - By Chris West - MIT Licensed
* http://gotochriswest.com/blog/2012/11/06/javascript-hash-table-implementation
******************************************************************************/
(function(g) {
    function k(b) {
        for (var b = arguments.length ? b : {}, c = {}, a, f = i.slice(0), e = 0; a = f[e++]; ) !j.call(b, a) ? c[a] = b[a] : f.splice(e, 1);
        for (a in b) j.call(b, a) && (f.push(a), c[a] = b[a]);
        var d = {
            o: c,
            k: f
        };
        this._ = function(a) {
            return a === g ? d : void 0
        };
        return this
    }
    for (var j = [].hasOwnProperty, i = "constructor hasOwnProperty isPrototypeOf prototypeIsEnumerable toLocaleString toString valueOf".split(" "), d, l = {}, h = 0; d = i[h]; h++) for (d in l[d] = h, l) i.splice(h--, 1), delete l[d];
    d = k.prototype;
    d.get = function(b) {
        return this._(g).o[b]
    };
    d.keys = function() {
        return this._(g).k.slice(0)
    };
    d.containsValue = d.contains = function(b) {
        for (var c = this._(g), a = c.k, c = c.o, f = a.length; 0 <= --f; ) if (c[a[f]] === b) return !0;
        return !1
    };
    d.containsKey = function(b) {
        for (var c = this._(g).k, a = c.length; 0 <= --a; ) if (c[a] == b) return !0;
        return !1
    };
    d.clear = function() {
        var b = this._(g),
            c = b.o;
        b.k = [];
        b.o = {};
        return c
    };
    d.elements = function() {
        for (var b = [], c = this._(g), a = c.k, f = 0, e = a.length, c = c.o; f < e; ) b.push(c[a[f++]]);
        return b
    };
    d.size = function() {
        return this._(g).k.length
    };
    d.remove = function(b) {
        for (var c =
            this._(g), a = c.k, c = c.o, f = a.length; 0 <= --f; ) if (a[f] == b) {
            var e = c[a.splice(f, 1)[0]];
            delete c[b];
            break
        }
        return e
    };
    d.put = function(b, c) {
        var a = this._(g),
            f = a.k,
            e = a.o;
        if (arguments.length - 1) j.call(e, b) ? d = e[b] : f.push(b), e[b] = c;
        else for (var d = {}, h = (new k(b)).keys(), i = h.length; 0 <= --i; ) a = h[i], j.call(e, a) ? d[a] = e[a] : f.push(a), e[a] = b[a];
        return d
    };
    d.clone = function() {
        return new k(this._(g).o)
    };
    d.isEmpty = function() {
        return !this._(g).k.length
    };
    d.equals = function(b) {
        var c, a;
        a = this._(g);
        var d = a.o;
        a = a.k;
        var e = b._(g),
            b = e.o,
            e =
                e.k;
        if (a.length != (a = e.length)) return !1;
        for (; 0 <= --a && j.call(d, c = e[a]) && d[c] === b[c]; );
        return 0 > a
    };
    d.forEach = function(b, c) {
        for (var a = this._(g), d = a.o, a = a.k, e = 0, h = a.length; e < h; e++) b.call(c, d[a[e]], a[e], this);
        return this
    };
    j.call(this, "Hashtable") && (k.__OLD__ = this.Hashtable);
    this.Hashtable = k
})({});