<template>
	<div class="container">
		<div class="subcontainer">
			<div class="menu-container">
				<div class="title-container">
					<p class="title">Currency Exchange</p>
				</div>
				<div class="currency-type-container">
					<select v-model="currency" class="currency-option" @change="onCurrencyChange">
						<option value="eur">EUR</option>
						<option value="usd">USD</option>
					</select>
				</div>
			</div>
			<div class="currency-value-container">
				<div class="left-container">
					<div class="flag-container">
						<div class="flag-1">
							<img class="image" alt="PL flag" src="../assets/pln.webp">
						</div>
						<div class="flag-name-1">Poland</div>
					</div>
					<div class="currency-name-container">
						<p class="currency-name-1">Rate: {{ rate }} PLN</p>
					</div>
					<div class="currency-input-container">
						<input class="currency-value-1" v-model="valuePLN" @keyup="calculatePLNtoCurr" type="number"/>
					</div>
				</div>
				<div v-if="currency != '' && !loading" class="right-container">
					<div class="flag-container">
						<div class="flag-2">
							<img class="image" alt="Currency flag" v-bind:src="require(`../assets/${currency}.webp`)">
						</div>
						<div class="flag-name-2">{{ text }}</div>
					</div>
					<div class="currency-name-container">
						<p class="currency-name-2">Rate: 1 {{ currency.toUpperCase() }}</p>
					</div>
					<div class="currency-input-container">
						<input class="currency-value-2" v-model="valueCurr" @keyup="calculateCurrToPLN" type="number"/>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
import axios from 'axios';
export default {
    name: 'CurrencyExchange',
	data(){
		return{
			currency: '',
			rate: 1.0,
			valuePLN: '',
			valueCurr: '',
			text: '',
			loading: false,
		}
	},
    methods: {
        async onCurrencyChange() {
			this.loading = true;
			await axios
			.get('https://api.nbp.pl/api/exchangerates/rates/a/'+this.currency+'/')
			.then(response => (this.rate = response.data.rates[0].mid))
			.catch(error => {console.log(error); this.currency=''});
			if(this.currency == 'eur'){
				this.text = 'European Union';
			}
			else{
				this.text = 'United States';
			}
			this.calculatePLNtoCurr();
			this.loading = false;
        },
		calculatePLNtoCurr(){
			this.valueCurr = this.valuePLN == ''? '' : (this.valuePLN / this.rate).toFixed(4);
		},
		calculateCurrToPLN(){
			this.valuePLN = this.valueCurr == ''? '' : (this.valueCurr * this.rate).toFixed(4);
		}
    },
}
</script>

<style>
	.container{
		display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
	}

	.subcontainer{
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
		width: 500px;
    }

	.menu-container{
		display: flex;
		flex-direction: row;
        justify-content: space-between;
        align-items: center;
		width: 100%;
		height: fit-content;
	}

	.title-container{
		display: flex;
		flex-direction: row;
        justify-content: center;
        align-items: center;
	}

	.title{
		font-size: 35px;
		font-weight: bold;
	}

	.currency-type-container{
		display: flex;
		justify-content: center;
		height: 50px;
		width: 100px;
	}

	.currency-option{
		display: flex;
		justify-content: center;
		height: 50px;
		width: 100px;
	}

	.currency-value-container{
		display: flex;
		flex-direction: row;
        justify-content: space-between;
        align-items: center;
		width: 100%;
	}

	.flag-name-1{
		font-size: 20px;
		font-weight: bold;
	}

	.flag-name-2{
		font-size: 20px;
		font-weight: bold;
	}

	.currency-value-1{
		font-size: 17px;
	}

	.currency-value-2{
		font-size: 17px;
	}

	.image{
		width: 120px;
		border-radius: 12px;
		border-style: solid;
		border-color: #000000;
		border-width: 1px;
	}
</style>