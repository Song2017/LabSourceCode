//归并排序 javascript
function merge(left, right) {
    var result = [];
    while (left.length > 0 && right.length > 0) {
        if (left[0] < right[0]) {
            result.push(left.shift());
        } else {
            result.push(right.shift());
        }
    }
    return result.concat(left).concat(right);
}
//for
function mergesort(items) {
    if (items.length == 1) {
        return items;
    }
 
    var work = [];

    for (var i = 0, len = items.length; i < len; i++) {
        work.push([items[i]]);
    }
    work.push([]);
    //mergesort([1,233,4,33,22,11])
    for (var lim = len; lim > 1; lim = (lim + 1) / 2) {
        for (var j = 0, k = 0; k < lim; j++, k += 2) {
            work[j] = merge(work[k], work[k + 1]);
            console.log("J:" + j + " wj:" + work[j]);
        }
        work[j] = [];
    }
    return work[0];
}

//recursive
function mergesort2(items) {
    if (items.length == 1) {
        return items;
    }

    var middle = Math.floor(items.length / 2);
    left = items.slice(0, middle);
    right = items.slice(middle);
    return merge(mergesort2(left), mergesort2(right));
}