funcAsync = (str, timeout) => new Promise(
    (resolve, reject) =>
        setTimeout(() => resolve(str), timeout)
);

(async () => {
    try {
        // console.log('start')
        const result = await funcAsync('hoge', 3000)
        console.log(result)
    } catch (error) {
        console.log(error)
    }
})()

funcAsync('fuga', 1000)
    .then(x => console.log(x))
    .catch(x => console.log(x))
