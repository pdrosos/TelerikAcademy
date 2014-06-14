function s(n) { if (!n) return .5; d = {}; n |= 0; return d.n ? d.n / 2 : d.n = (4 * n - 2) * s(n - 1) / (n + 1) }

console.log(s(7));