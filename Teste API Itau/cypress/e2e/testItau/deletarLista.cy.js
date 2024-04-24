import LoginHomePage from '../e2e/testItau/loginHome'


LoginHomePage.visit();

describe('Deletar Lista de Itens',()=>{

    it('Navegar Até Seção de Deletar Lista', ()=>{

       cy.get('botaoDeletar').click()
       cy.url().expect('INSIRA URL DE DELETAR AQUI')

    })

    it('Deletar Lista', ()=>{

        cy.contains('tabelaDeletar'),
        cy.get('botaoDeletarDeletar').click(),
        cy.url().expect('INSIRA URL DE SUCESSO AQUI'),
        cy.get('botaoInicio').click()
 
     })
})